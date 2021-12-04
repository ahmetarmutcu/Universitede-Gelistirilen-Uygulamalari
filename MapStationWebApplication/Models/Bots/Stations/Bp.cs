using Newtonsoft.Json;
using StationShowApplication.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace StationShowApplication.Models.Bots.Stations
{
    public class Bp
    {
        public static List<DataStation> getData()
        {
            StationDb db = new StationDb();
            List<Point> points = new List<Point>();
            List<string> ids = new List<string>();
            double enlem = 24.0;
            while (enlem < 45.5)
            {
                double boylam = 36.0;
                while (boylam < 44.6)
                {
                    string res = StringHelper.GetResponsive("https://bpretaillocator.geoapp.me/api/v1/locations/nearest_to?lat=" +
                        ""+enlem+"&lng="+boylam+"&autoload=true&" +
                        "travel_mode=driving&avoid_tolls=false&avoid_highways=false&show_stations_on_route=true&corridor_radius=5&" +
                        "key=AIzaSyDHlZ-hOBSpgyk53kaLADU18wq00TLWyEc&format=json").Trim();
                    if (res != null ||res!="")
                    {
                        var dataInfo = JsonConvert.DeserializeObject<List<BpStationObject>>(res);
                        if (dataInfo.Count > 0 && dataInfo != null && dataInfo.ToString()!="")
                        {
                            foreach (var item in dataInfo)
                            {
                                if (ids.Contains(item.id))
                                    continue;
                                var yesNoControl = db.DataStation.Where(x => x.stationAdres == item.address && x.stationName == item.name).
                                    FirstOrDefault();
                                if (yesNoControl == null)
                                {
                                    Point p = new Point();
                                    p.name = item.name;
                                    p.city = item.city;
                                    p.country = "";
                                    p.address = item.address;
                                    p.lat = item.lat.ToString().Replace(",", ".");
                                    p.lng = item.lng.ToString().Replace(",", ".");
                                    p.typeId = 2;
                                    p.pointWriteType = "Otomatik";
                                    p.pointWriteDateTime = DateTime.Now;
                                    ids.Add(item.id);
                                    points.Add(p);
                                }

                            }
                        }
                    }
                    boylam = boylam + 0.5;
                }
                enlem = enlem + 0.5;
            }
            foreach (var bp in points)
            {
                DataStation point = new DataStation();
                point.stationName = bp.name;
                point.stationAdres = bp.address;
                point.stationCity = bp.city;
                point.stationCountry = bp.country;

                point.stationLatX = bp.lat;
                point.stationLatY = bp.lng;
                point.stationTypeId = bp.typeId;
                point.stationWriteType = bp.pointWriteType;
                point.stationWriteDateTime = bp.pointWriteDateTime;
                db.DataStation.Add(point);
                db.SaveChanges();
            }
            return (db.DataStation.Where(x => x.stationTypeId == 2 && x.stationWriteType == "Otomatik").ToList());
        }

        public static void getFuelPriceList()
        {
            string baseUrl = "https://www.shell.com.tr/suruculer/shell-yakitlari/akaryakit-pompa-satis-fiyatlari.html";
            string res = Helper.StringHelper.GetResponsive(baseUrl);
            if (res != null && res != "")
            {

            }
        }
    }
    public class BpStationObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }
}