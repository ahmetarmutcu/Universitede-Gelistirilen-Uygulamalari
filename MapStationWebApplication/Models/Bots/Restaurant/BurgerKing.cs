using Newtonsoft.Json;
using StationShowApplication.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationShowApplication.Models.Bots.Restaurant
{
    public class BurgerKing
    {
        
        public static List<DataStation> getData()
        {
            StationDb db = new StationDb();
            List<Point> restoranlar = new List<Point>();
            string baseUrl = "https://www.burgerking.com.tr/Restaurants/GetRestaurants/";
            string res = Helper.StringHelper.GetResponsive(baseUrl);
            if (res != null)
            {
                List<BurgerObject> objeList = JsonConvert.DeserializeObject<List<BurgerObject>>(res);
                if (objeList != null && objeList.Count > 0)
                {
                    int len = objeList.Count;
                    for (int i = 0; i < len; i++)
                    {
                        var item = objeList[i];

                        var yesNoControl = db.DataStation.Where(x => x.stationAdres == item.data.address && x.stationName == item.data.title).FirstOrDefault();
                        if (yesNoControl == null)
                        {
                            Point resturantInfo = new Point();
                            resturantInfo.name = item.data.title;
                            resturantInfo.city = item.data.city;
                            resturantInfo.country = "";
                            resturantInfo.address = item.data.address;
                            resturantInfo.lat = item.lat.Replace(",", ".");
                            resturantInfo.lng = item.lng.Replace(",", ".");
                            resturantInfo.typeId = 7;
                            resturantInfo.pointWriteType = "Otomatik";
                            resturantInfo.pointWriteDateTime = DateTime.Now;
                            restoranlar.Add(resturantInfo);
                        }
                    }
                }
            }
            foreach (var stationItem in restoranlar)
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
            return (db.DataStation.Where(x => x.stationTypeId == 7 && x.stationWriteType == "Otomatik").ToList());
        }
    }

    public class BurgerData
    {
        public string title { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }

    public class BurgerObject
    {
        public string lat { get; set; }
        public string lng { get; set; }
        public BurgerData data { get; set; }
        public BurgerObject()
        {
            data = new BurgerData();
        }
    }

}