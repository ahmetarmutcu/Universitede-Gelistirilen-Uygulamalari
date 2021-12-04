mapboxgl.accessToken = 'pk.eyJ1IjoiYWhtZXRhcm11dGN1IiwiYSI6ImNrYWR3djJzdTAzYm8ycnFwcnV6N3o3N3YifQ.MDbrxhRvlAEC5A4B4s-NiA';

var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [37, 40],
    zoom: 5
});
window.onload = function () {
    getLocation();
};


var l = new Object();
l.id = 0;
var canvas = map.getCanvasContainer();
var start = [];
function getLocation() {
    // Tarayıcınız  Geolocation API desteği var mı?
    if (!navigator.geolocation) {
        alert('Tarayıcınız Geolocation desteği bulunmuyor');
    } else {
        navigator.geolocation.getCurrentPosition(function (position) {
            // Mevcut pozisyonumuzu alıyoruz
            var data = new Object();
            data.getLo = "";
            var lat = position.coords.latitude;
            var lng = position.coords.longitude;
            start = [Number(lng), Number(lat)];
            data.getLo = lat + "-" + lng;
            data.getLo = JSON.stringify({ data: data.getLo });
            $.ajax({
                url: '/Station/NearestStationdData/',
                data: data.getLo,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    window.stations = $.parseJSON(response);
                    var listings = document.getElementById('listings');
                    for (var item in window.stations) {

                        var x = parseFloat(window.stations[item].lat);
                        var y = parseFloat(window.stations[item].lng);
                        var button = listings.appendChild(document.createElement('div'));
                        button.id = "listing-" + window.stations[item].pointId;
                        button.className = 'item';
                        var link = button.appendChild(document.createElement('a'));
                        link.href = '#';
                        link.className = 'title';
                        link.id = "link-" + window.stations[item].pointId;
                        link.innerHTML = window.stations[item].name + " (" + window.stations[item].sektorName + " )";
                        var details = button.appendChild(document.createElement('div'));
                        details.style.color = "white";
                        details.innerHTML = window.stations[item].city + " / " + window.stations[item].country + "<br>";
                        if (window.stations[item].address) {
                            details.innerHTML += '-' + window.stations[item].address;
                        }
                        var el = document.createElement('div');
                        el.className = 'marker';
                        new mapboxgl.Marker(el)
                            .setLngLat([y, x])
                            .setPopup(
                                new mapboxgl.Popup({ offset: 25 }) // add popups
                                    .setHTML(
                                        '<h3>' +
                                        window.stations[item].name +
                                        '</h3><p>' +
                                        window.stations[item].address +
                                        '</p><p>' +
                                        window.stations[item].city +
                                        '</p><p>' +
                                        window.stations[item].country +
                                        '</p>'
                                    )
                            )
                            .addTo(map);
                    }
                    $('.item').click(function () {
                        l.id = this.id.split('-').pop();
                        $.ajax({
                            url: '/Station/GetStation/',
                            data: JSON.stringify(l),
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            success: function (response) {

                                var rotaPaneli = document.getElementById("instructions");
                                rotaPaneli.style.display = "block";
                                var obje = $.parseJSON(response);
                                getRoute(start);
                                map.addLayer({
                                    'id': 'point',
                                    'type': 'circle',
                                    'source': {
                                        'type': 'geojson',
                                        'data': {
                                            'type': 'FeatureCollection',
                                            'features': [
                                                {
                                                    'type': 'Feature',
                                                    'properties': {},
                                                    'geometry': {
                                                        'type': 'Point',
                                                        'coordinates': start
                                                    }
                                                }
                                            ]
                                        }
                                    },
                                    'paint': {
                                        'circle-radius': 10,
                                        'circle-color': '#3887be'
                                    }
                                });

                                var coordsObj = [Number(obje[0].lng), Number(obje[0].lat)];
                                canvas.style.cursor = '';
                                var coords = Object.keys(coordsObj).map(function (key) {
                                    return coordsObj[key];
                                });
                                var end = {
                                    'type': 'FeatureCollection',
                                    'features': [
                                        {
                                            'type': 'Feature',
                                            'properties': {},
                                            'geometry': {
                                                'type': 'Point',
                                                'coordinates': coords
                                            }
                                        }
                                    ]
                                };
                                if (map.getLayer('end')) {
                                    map.getSource('end').setData(end);
                                } else {
                                    map.addLayer({
                                        'id': 'end',
                                        'type': 'circle',
                                        'source': {
                                            'type': 'geojson',
                                            'data': {
                                                'type': 'FeatureCollection',
                                                'features': [
                                                    {
                                                        'type': 'Feature',
                                                        'properties': {},
                                                        'geometry': {
                                                            'type': 'Point',
                                                            'coordinates': coords
                                                        }
                                                    }
                                                ]
                                            }
                                        },
                                        'paint': {
                                            'circle-radius': 10,
                                            'circle-color': '#f30'
                                        }
                                    });
                                }
                                getRoute(coords);
                                map.flyTo({
                                    center: coordsObj,
                                    essential: true,
                                    zoom: 12
                                });
                            }
                        });
                    });
                }

            });
        });
    }
}
function getRoute(end) {
    var url =
        'https://api.mapbox.com/directions/v5/mapbox/cycling/' +
        start[0] +
        ',' +
        start[1] +
        ';' +
        end[0] +
        ',' +
        end[1] +
        '?steps=true&geometries=geojson&access_token=' +
        mapboxgl.accessToken;

    var req = new XMLHttpRequest();
    req.open('GET', url, true);
    req.onload = function () {
        var json = JSON.parse(req.response);
        var data = json.routes[0];
        var route = data.geometry.coordinates;
        var geojson = {
            'type': 'Feature',
            'properties': {},
            'geometry': {
                'type': 'LineString',
                'coordinates': route
            }
        };
        // if the route already exists on the map, we'll reset it using setData
        if (map.getSource('route')) {
            map.getSource('route').setData(geojson);
        }
        // otherwise, we'll make a new request
        else {
            map.addLayer({
                'id': 'route',
                'type': 'line',
                'source': {
                    'type': 'geojson',
                    'data': {
                        'type': 'Feature',
                        'properties': {},
                        'geometry': {
                            'type': 'LineString',
                            'coordinates': geojson
                        }
                    }
                },
                'layout': {
                    'line-join': 'round',
                    'line-cap': 'round'
                },
                'paint': {
                    'line-color': '#3887be',
                    'line-width': 5,
                    'line-opacity': 0.75
                }
            });
        }

        // get the sidebar and add the instructions
        var instructions = document.getElementById('instructions');
        var steps = data.legs[0].steps;

        var tripInstructions = [];
        for (var i = 0; i < steps.length; i++) {
            tripInstructions.push('<br><li>' + steps[i].maneuver.instruction) +
                '</li>';
            instructions.innerHTML =
                '<br><h2>Rota Belirlendi</h2><span style=color:red>' +
                Math.floor(data.duration / 60) +
                ' dakika</span>' +
                tripInstructions;
        }
    };
    req.send();
}
