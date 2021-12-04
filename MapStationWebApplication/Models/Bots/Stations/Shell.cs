using Newtonsoft.Json;
using StationShowApplication.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationShowApplication.Models.Bots.Stations
{
    public class Shell
    {
        public static List<DataStation> getData()
        {
            StationDb db = new StationDb();

            List<string> link = new List<string>();
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/within_bounds?sw%5B%5D=38.84&sw%5B%5D=26.807&ne%5B%5D=39.744&ne%5B%5D=28.659&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=20&driving_distances=true&format=json");
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/nearest_to?lat=38.74758&lng=28.43616&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=5&driving_distances=false&format=json");
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/nearest_to?lat=38.74758&lng=28.43616&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=5&driving_distances=false&format=json");
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/nearest_to?lat=38.84233&lng=28.65118&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=5&driving_distances=false&format=json");
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/nearest_to?lat=38.4125&lng=33.95014&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=5&driving_distances=false&format=json");
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/nearest_to?lat=40.66817&lng=35.63706&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=5&driving_distances=false&format=json");
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/nearest_to?lat=40.52674&lng=41.0372&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=5&driving_distances=false&format=json");
            link.Add("https://shellgsllocator.geoapp.me/api/v1/locations/nearest_to?lat=39.50185&lng=43.4847&selected=&autoload=true&travel_mode=driving&avoid_tolls=false&avoid_highways=false&avoid_ferries=false&corridor_radius=5&driving_distances=false&format=json");
          
            List<Point> points = new List<Point>();
            HashSet<string> ids = new HashSet<string>();
            //double enlem = 26.0;
            //while (enlem < 45.0)
            //{
            //    double boylam = 36.0;
            //    while (boylam < 43)
            //    {
            foreach (var baseUrl in link)
            {
                string result = StringHelper.GetResponsive(baseUrl);
                if (result != null && result != "")
                {
                    List<ShellRootObject> shellObject = JsonConvert.DeserializeObject<List<ShellRootObject>>(result);
                    if (shellObject != null && shellObject.Count > 0)
                    {
                        for (int i = 0; i < shellObject.Count; i++)
                        {
                            if (shellObject[i].country_code == "TR")
                            {
                                var stationAddres = shellObject[i].address;
                                var stationName = shellObject[i].name;
                                if (ids.Contains(shellObject[i].id))
                                    continue;
                                var yesNoControl = db.DataStation.Where(x => x.stationAdres == stationAddres && x.stationName == stationName).FirstOrDefault();
                                if (yesNoControl == null)
                                {
                                    Point p = new Point();
                                    p.name = shellObject[i].name;
                                    p.city = shellObject[i].city;
                                    p.country = shellObject[i].country;
                                    p.address = shellObject[i].address;
                                    p.lat = shellObject[i].lat.ToString().Replace(",", ".");
                                    p.lng = shellObject[i].lng.ToString().Replace(",", ".");
                                    p.typeId = 3;
                                    p.pointWriteType = "Otomatik";
                                    p.pointWriteDateTime = DateTime.Now;
                                    ids.Add(shellObject[i].id);
                                    points.Add(p); ;
                                }
                            }

                        }

                        //        }
                        //    }
                        //    boylam += 0.5;
                        //}
                        //enlem += 0.5;

                    }
                }
                
            }
            foreach (var stationItem in points)
            {
                DataStation dataStation = new DataStation();
                dataStation.stationName = stationItem.name;
                dataStation.stationCity = stationItem.city;
                dataStation.stationCountry = stationItem.country;
                dataStation.stationAdres = stationItem.address;
                dataStation.stationLatX = stationItem.lat;
                dataStation.stationLatY = stationItem.lng;
                dataStation.stationTypeId = stationItem.typeId;
                dataStation.stationWriteType = stationItem.pointWriteType;
                dataStation.stationWriteDateTime = stationItem.pointWriteDateTime;
                db.DataStation.Add(dataStation);
                db.SaveChanges();
            }
            return (db.DataStation.Where(x => x.stationTypeId == 3 && x.stationWriteType == "Otomatik").ToList());
        } 

    }
    public class ShellRootObject
    {
        public string id { get; set; }
        public string country_code { get; set; }
        public string name { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public double distance { get; set; }
        public object driving_distance { get; set; }
        public object driving_duration { get; set; }
        public string website_url { get; set; }
        public string open_status { get; set; }
        public object next_open_status_change { get; set; }
        public int tz_offset { get; set; }
        public IList<string> fuels { get; set; }
        public object next_forecourt_open_status_change { get; set; }
        public object next_shop_open_status_change { get; set; }
        public string forecourt_open_status { get; set; }
        public string shop_open_status { get; set; }
    }
}