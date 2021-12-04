
mapboxgl.accessToken = 'pk.eyJ1IjoiYWhtZXRhcm11dGN1IiwiYSI6ImNrYWR3djJzdTAzYm8ycnFwcnV6N3o3N3YifQ.MDbrxhRvlAEC5A4B4s-NiA';
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [36, 38], //harita pozisyonu
    zoom: 4 // harita başlangıç zoomu
});

//Haritanın hangi konumda olduğuna ayarlıyoruz.
var bounds = [
    [24, 35],
    [48, 44]
];
map.setMaxBounds(bounds);

//Zoom Control
var nav = new mapboxgl.NavigationControl();
map.addControl(nav, 'top-left');






//Konum gösterme
var getLocation = new mapboxgl.GeolocateControl({
    positionOptions: {
        enableHighAccuracy: true
    },
    trackUserLocation: true,
});
map.addControl(getLocation, 'top-left');




//İstasyon Noktalarının harita üzerinde gösterilmesi
var url = '/Station/FetchPointData';
$.getJSON(url, function (data) {
    for (var item in data.Result) {
        var el= document.createElement('div');
        if (data.Result[item].typeId === 2) {

            el.className = 'Bpmarker';
            el.style.backgroundImage = "url('../Content/Station/Maps/img/MarkerIcon/bpIcon.png')";
        }
        else if (data.Result[item].typeId === 3) {

            el.className = 'Shellmarker';
            el.style.backgroundImage = "url('../Content/Station/Maps/img/MarkerIcon/shell_Icon.png')";
        }
        else if (data.Result[item].typeId === 4) {
            el.className = 'eczaneMarker';
            el.style.backgroundImage = "url('../Content/Station/Maps/img/MarkerIcon/eczane.png')";
        }
        else if (data.Result[item].typeId === 7) {
            el.className = 'restaurantsMarker';
            el.style.backgroundImage = "url('../Content/Station/Maps/img/MarkerIcon/resturantIcon.jpg')";
        }
        else {
            el.className = 'POmarker';
            el.style.backgroundImage = "url('../Content/Station/Maps/img/MarkerIcon/poIcon.png')";
        }
        new mapboxgl.Marker(el)
            .setLngLat([data.Result[item].lng, data.Result[item].lat])
            .setPopup(
                new mapboxgl.Popup({ offset: 25 }) // add popups
                    .setHTML(
                        '<h4>' +
                        data.Result[item].name + '(' + data.Result[item].sektorName+
                        ')</h4><p>' +
                        data.Result[item].address +
                        '</p><p>' +
                        data.Result[item].country + "/" + data.Result[item].city +
                        '</p>'
                    )
            ).addTo(map);
    }
});


//Haritayı büyütme
map.addControl(new mapboxgl.FullscreenControl());


map.addControl(
    new MapboxDirections({
        accessToken: mapboxgl.accessToken
    }),
    'top-right'
);

//Harita katman stillerini belirliyoruz
var layerList = document.getElementById("katmanlar");
var inputs = layerList.getElementsByTagName('input');
function switchLayer(layer) {
    var layerId = layer.target.id;
    map.setStyle('mapbox://styles/mapbox/' + layerId);
}
for (var i = 0; i < inputs.length; i++) {
    inputs[i].onclick = switchLayer;
}



var rotationSidebar = document.getElementById("rotationSidebar");
function GuzergayaGoreIstasyonBul() {
    var fuel = new Object();
    fuel.id = 0;
    var rotaKoordinatlari = document.getElementsByClassName("mapbox-directions-step");
    if (rotaKoordinatlari.length > 0) {
        rotationSidebar.style.display = "block";
        var rotaList = [];
        for (var i = 0; i < rotaKoordinatlari.length; i++) {
            rotaList[i] = (rotaKoordinatlari[i].dataset.lat + "-" + rotaKoordinatlari[i].dataset.lng);
        }
        $.ajax({
            url: '/Station/TwoPointBeetweenStation',
            data: JSON.stringify({
                rotaKoordinatlari: rotaList
            }),
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                window.stations = $.parseJSON(response);
                var listings = document.getElementById('listings');
                listings.innerHTML = "";
                for (var item in window.stations) {

                    var x = parseFloat(window.stations[item].lat);
                    var y = parseFloat(window.stations[item].lng);
                    var button = listings.appendChild(document.createElement('div'));
                    button.id = "listing-" + window.stations[item].pointId;
                    button.className = 'item';

                    var link = button.appendChild(document.createElement('a'));
                    link.className = 'title';
                    link.id = "link-" + window.stations[item].pointId;
                    link.style.fontSize = "12px";
                    link.innerHTML = window.stations[item].name + " (" + window.stations[item].sektorName+")";

                    var details = button.appendChild(document.createElement('div'));
                    details.style.fontSize = "10px";
                    details.innerHTML = window.stations[item].city + " / " + window.stations[item].country;

                    if (window.stations[item].address) {
                        details.innerHTML += '-' + window.stations[item].address;
                    }
                }
                $('.title').click(function () {
                    var a = document.getElementById("stationFuelPrice");
                    a.style.display = "block";
                    fuel.id = this.id.split('-').pop();
                    $.ajax({
                        url: '/Station/getFuelTypeAndPrice/',
                        data: JSON.stringify(fuel),
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        success: function (response) {
                            window.fuel = $.parseJSON(response);
                            for (var item in window.fuel) {
                                var akaryakitTablosu = document.getElementById('akaryakitTablosu');
                                akaryakitTablosu.innerHTML = "";
                                var anaDiv = document.createElement("div");
                                anaDiv.className = "fuel_ana_div";
                                var fuelAndPrice = window.fuel[item].fuelPrice;
                                for (var i = 0; i < fuelAndPrice.length; i++) {
                                    var div = document.createElement("div");
                                    div.className = "fuel_div";
                                    var divFuel = div.appendChild(document.createElement("div"));
                                    divFuel.style.fontWeight = "bold";
                                    divFuel.style.color = "black";
                                    divFuel.innerHTML = fuelAndPrice[i].fuelName;
                                    var divPrice = div.appendChild(document.createElement("div"));
                                    divPrice.style.fontWeight = "bold";
                                    divPrice.style.color = "red";
                                    divPrice.innerHTML = fuelAndPrice[i].price;
                                    anaDiv.appendChild(div);
                                }
                                akaryakitTablosu.appendChild(anaDiv);
                            }


                        }
                    });
                });
            }
        });
    }
    else {
        alert("Lütfen Güzergah seçiniz");
    }
}
function BulKapat() {
    var rotationSidebar = document.getElementById("rotationSidebar");
    rotationSidebar.style.display = "none";
    var akaryakitTablo = document.getElementById("stationFuelPrice");
    akaryakitTablo.style.display = "none";
}
function orderSectorSidebarClose() {
    var orderTable = document.getElementById("orderSectorSidebar");
    orderTable.style.display = "none";
}

function Katmanlar() {
    var katmanWindow = document.getElementById("KatmanWindow");
    katmanWindow.style.display = "block";
}


//function UcBoyutluMapDonustur() {
//    map.on('load', function () {
//        var layers = map.getStyle().layers;

//        var labelLayerId;
//        for (var i = 0; i < layers.length; i++) {
//            if (layers[i].type === 'symbol' && layers[i].layout['text-field']) {
//                labelLayerId = layers[i].id;
//                break;
//            }
//        }
//        map.addLayer(
//            {
//                'id': '3d-buildings',
//                'source': 'composite',
//                'source-layer': 'building',
//                'filter': ['==', 'extrude', 'true'],
//                'type': 'fill-extrusion',
//                'minzoom': 15,
//                'paint': {
//                    'fill-extrusion-color': '#aaa',

//                    'fill-extrusion-height': [
//                        'interpolate',
//                        ['linear'],
//                        ['zoom'],
//                        15,
//                        0,
//                        15.05,
//                        ['get', 'height']
//                    ],
//                    'fill-extrusion-base': [
//                        'interpolate',
//                        ['linear'],
//                        ['zoom'],
//                        15,
//                        0,
//                        15.05,
//                        ['get', 'min_height']
//                    ],
//                    'fill-extrusion-opacity': 0.6
//                }
//            },
//            labelLayerId
//        );
//    });
//}


function FindPointsAroundLocation() {
    window.location.href = "/Station/LocationToStation";
}

document.getElementById("sektorBtn").onclick = function () {

    var otherSector = document.getElementById("orderSectorSidebar");
    otherSector.style.display = "block";
};
document.getElementById("akaryakitBtn").onclick = function () {

    var otherSector = document.getElementById("akaryakitModul");
    otherSector.style.display = "block";
};


//Alternatif Sektorler
$('#tum').click(function () {
    BenzinlikShowMarker();
    EczanelerShowMarker();
    RestorantShowMarker();
});
$('#benzinIstasyonlari').click(function () {
    BenzinlikShowMarker();
    EczanelerHiddenMarker();
    RestorantHiddenMarker();
});
$('#restaurants').click(function () {
   
    BenzinlikHiddenMarker();
    EczanelerHiddenMarker();
    RestorantShowMarker();
});
$('#eczaneler').click(function () {
    BenzinlikHiddenMarker();
    RestorantHiddenMarker();
    EczanelerShowMarker();
});

function BenzinlikHiddenMarker() {
    var BpMarker = document.getElementsByClassName("Bpmarker");
    for (var i = 0; i < BpMarker.length; i++) {
        BpMarker[i].style.visibility = "hidden";
    }
    var ShellMarker = document.getElementsByClassName("Shellmarker");
    for (var j = 0; j < ShellMarker.length; j++) {
        ShellMarker[j].style.visibility = "hidden";
    }
    var POmarker = document.getElementsByClassName("POmarker");
    for (var p = 0; p < POmarker.length; p++) {
        POmarker[p].style.visibility = "hidden";
    }
}
function BenzinlikShowMarker() {
    var BpMarker = document.getElementsByClassName("Bpmarker");
    for (var i = 0; i < BpMarker.length; i++) {
        BpMarker[i].style.visibility = "visible";
    }
    var ShellMarker = document.getElementsByClassName("Shellmarker");
    for (var j = 0; j < ShellMarker.length; j++) {
        ShellMarker[j].style.visibility = "visible";
    }
    var POmarker = document.getElementsByClassName("POmarker");
    for (var p = 0; p < POmarker.length; p++) {
        POmarker[p].style.visibility = "visible";
    }
}
function EczanelerHiddenMarker() {
    var eczaneMarker = document.getElementsByClassName("eczaneMarker");
    for (var i = 0; i < eczaneMarker.length; i++) {
        eczaneMarker[i].style.visibility = "hidden";
    }
}
function EczanelerShowMarker() {
    var eczaneMarker = document.getElementsByClassName("eczaneMarker");
    for (var i = 0; i < eczaneMarker.length; i++) {
        eczaneMarker[i].style.visibility = "visible";
    }
}

function RestorantHiddenMarker() {
    var resturantMarker = document.getElementsByClassName("restaurantsMarker");
    for (var i = 0; i < resturantMarker.length; i++) {
        resturantMarker[i].style.visibility = "hidden";
    }
}

function RestorantShowMarker() {
    var resturantMarker = document.getElementsByClassName("restaurantsMarker");
    for (var i = 0; i < resturantMarker.length; i++) {
        resturantMarker[i].style.visibility = "visible";
    }
}


var catchmentObject = new Object();
catchmentObject.lat = "";
catchmentObject.lng = "";
catchmentObject.distance = "";
catchmentObject.pointTypes = [];

map.on('mousedown', function (e) {
    var catchmentPaneli = document.getElementById("noktaAnaliz");
    catchmentPaneli.style.display = "block";
    var coordinate = JSON.stringify(e.lngLat.wrap());
    data = JSON.parse(coordinate);
    catchmentObject.lat = data.lat;
    catchmentObject.lng = data.lng;
});
var catchmentAnalizBtn= document.getElementById("catchmentAnalizi");
catchmentAnalizBtn.onclick = function () {
    document.getElementById("catchmentModulu").style.display = "block";
   
};

var btnCatchmentAnaliziBtn = document.getElementById("btnCatchmentAnalizi");
btnCatchmentAnaliziBtn.onclick = function () {


    var pointTypeId = [];
    var catchmentBenzinlikler = document.getElementById("catchmentbenzinIstasyonlari");
    var catchmentrestaurants = document.getElementById("catchmentrestaurants");
    var catchmenteczaneler = document.getElementById("catchmenteczaneler");
    if (catchmentBenzinlikler.checked === false && catchmentrestaurants.checked === false && catchmenteczaneler.checked === false) {
        alert("Lütfen sektör seçiniz");
    }
    if (catchmentBenzinlikler.checked === true) {
        pointTypeId = [1, 2, 3];
    }
    else if (catchmentrestaurants.checked === true) {
        pointTypeId = [7];
    }
    else
    {
        pointTypeId = [4];
    }
    catchmentObject.pointTypes = pointTypeId;
    var catchmentInput = document.getElementById("catchmentInput");
    catchmentObject.distance = catchmentInput.value;
    if (catchmentInput.value !== "") {
        $.ajax({
            url: '/Station/CatchmentAnalizi/',
            data: JSON.stringify(catchmentObject),
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                window.points = $.parseJSON(response);
                var listings = document.getElementById('catchmentAnaliz');
                listings.innerHTML = "";
                for (var item in window.points) {

                    var x = parseFloat(window.points[item].lat);
                    var y = parseFloat(window.points[item].lng);
                    var button = listings.appendChild(document.createElement('div'));
                    button.id = "listing-" + window.points[item].pointId;
                    button.className = 'item';

                    var link = button.appendChild(document.createElement('a'));
                    link.className = 'title';
                    link.id = "link-" + window.points[item].pointId;
                    link.style.fontSize = "12px";
                    link.innerHTML = window.points[item].name + "(" + window.points[item].sektorName + ")";

                    var details = button.appendChild(document.createElement('div'));
                    details.style.fontSize = "10px";
                    details.innerHTML = window.points[item].city + "/" + window.points[item].country+"<br>";

                    if (window.points[item].address) {
                        details.innerHTML += '-' + window.points[item].address;
                    }
                }
            }
        });
    }
    else {
        alert("Lütfen mesafeyi giriniz");
    }
}

function noktaPaneliKapat() {
    document.getElementById("noktaAnaliz").style.display = "none";
    document.getElementById("catchmentModulu").style.display = "none";
}
function catchmentModuluKapat() {
    document.getElementById("catchmentModulu").style.display = "none";
}
function KatmanKapat() {
    var katmanWindow = document.getElementById("KatmanWindow");
    katmanWindow.style.display = "none";
}
function AkaryakitTablosuKapat() {
    var akaryakitTablo = document.getElementById("stationFuelPrice");
    akaryakitTablo.style.display = "none";
}
function AkaryakitModulKapat() {
    var akaryakitModul = document.getElementById("akaryakitModul");
    akaryakitModul.style.display = "none";
}
function AkaryakitModulListKapat() {
    var akaryakitModul = document.getElementById("akaryakitModulList");
    akaryakitModul.style.display = "none";
}
//Sayfa yüklenirken
window.onload = function () {

    var fuel = new Object();
    fuel.id = 0;
    var akaryakitDiv = document.getElementById("akaryakitDiv");
    var url = '/Station/GetFuel';
    $.getJSON(url, function (data) {
        for (var item in data.Result) {

            var input = document.createElement("input");
            input.type = "radio";
            input.id = "input-" + data.Result[item].pointId;
            input.name = "akaryakitlar";

            var labelFuel = document.createElement("label");
            labelFuel.innerHTML = data.Result[item].name;

            var br = document.createElement("br");
            akaryakitDiv.appendChild(input);
            akaryakitDiv.appendChild(labelFuel);
            akaryakitDiv.appendChild(br);
        }
        var btn = document.createElement("input");
        btn.type = "button";
        btn.value = "Filtrele";
        btn.id = "akaryakitFiltreBtn";
        btn.style.marginLeft = "145px";
        akaryakitDiv.appendChild(btn);
        var akaryakitFiltreBtn = document.getElementById("akaryakitFiltreBtn");
        akaryakitFiltreBtn.onclick = function () {

            var rotaKoordinatlari = document.getElementsByClassName("mapbox-directions-step");
            if (rotaKoordinatlari.length > 0) {
                var rotaList = [];
                for (var i = 0; i < rotaKoordinatlari.length; i++) {
                    rotaList[i] = (rotaKoordinatlari[i].dataset.lat + "-" + rotaKoordinatlari[i].dataset.lng);
                }
                var inputs = document.getElementsByName("akaryakitlar");
                for (var j = 0; j < inputs.length; j++) {
                    if (inputs[j].checked === true) {
                        fuel.id = inputs[j].id.split('-').pop();
                        $.ajax({
                            url: '/Station/GetFuelPriceOrderByStation/',
                            data: JSON.stringify({
                                rotaKoordinatlari: rotaList,
                                json: fuel
                            }),
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            success: function (response) {

                                document.getElementById("akaryakitModulList").style.display = "block";
                                var listings = document.getElementById('akaryakitListDiv');
                                listings.innerHTML = "";
                                window.points = $.parseJSON(response);
                                for (var item in window.points) 
                                {

                                    var x = parseFloat(window.points[item].lat);
                                    var y = parseFloat(window.points[item].lng);
                                    var button = listings.appendChild(document.createElement('div'));
                                    button.id = "listing-" + window.points[item].pointId;
                                    button.className = 'item';

                                    var link = button.appendChild(document.createElement('a'));
                                    link.className = 'title';
                                    link.id = "link-" + window.points[item].pointId;
                                    link.style.fontSize = "12px";
                                    link.innerHTML = window.points[item].name + "(" + window.points[item].sektorName + ")";

                                    var details = button.appendChild(document.createElement('div'));
                                    details.style.fontSize = "10px";
                                    details.innerHTML = window.points[item].city + "/" + window.points[item].country + "<br>";

                                    if (window.points[item].address) {
                                        details.innerHTML += '-' + window.points[item].address;
                                    }
                                }
                                $('.title').click(function () {
                                    var a = document.getElementById("stationFuelPrice");
                                    a.style.display = "block";
                                    fuel.id = this.id.split('-').pop();
                                    $.ajax({
                                        url: '/Station/getFuelTypeAndPrice/',
                                        data: JSON.stringify(fuel),
                                        type: 'POST',
                                        contentType: 'application/json; charset=utf-8',
                                        success: function (response) {
                                            window.fuel = $.parseJSON(response);
                                            for (var item in window.fuel) {
                                                var akaryakitTablosu = document.getElementById('akaryakitTablosu');
                                                akaryakitTablosu.innerHTML = "";
                                                var anaDiv = document.createElement("div");
                                                anaDiv.className = "fuel_ana_div";
                                                var fuelAndPrice = window.fuel[item].fuelPrice;
                                                for (var i = 0; i < fuelAndPrice.length; i++) {
                                                    var div = document.createElement("div");
                                                    div.className = "fuel_div";
                                                    var divFuel = div.appendChild(document.createElement("div"));
                                                    divFuel.style.fontWeight = "bold";
                                                    divFuel.style.color = "black";
                                                    divFuel.innerHTML = fuelAndPrice[i].fuelName;
                                                    var divPrice = div.appendChild(document.createElement("div"));
                                                    divPrice.style.fontWeight = "bold";
                                                    divPrice.style.color = "red";
                                                    divPrice.innerHTML = fuelAndPrice[i].price;
                                                    anaDiv.appendChild(div);
                                                }
                                                akaryakitTablosu.appendChild(anaDiv);
                                            }


                                        }
                                    });
                                });
                                document.getElementById("akaryakitModul").style.display = "none";
                            }
                        });

                    }
                }
            }
            else {
                alert("Lütfen güzergah belirleyiniz");
            }
        }
    });

};

