using StationShowApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft;
using StationShowApplication.Models.Helper;
using System.Device.Location;
using System.Collections;

namespace StationShowApplication.Controllers
{
    public class StationController : Controller
    {
        StationDb db = new StationDb();
        // GET: Station
        public ActionResult StationIndex()
        {
            return View(db.DataStation.Select(x => x.stationAdres).Distinct().ToList());
        }
        /// <summary>
        /// Harita üzerinde gösterilecek nokta bilgileri
        /// </summary>
        /// <returns></returns>
        public JsonResult FetchPointData()
        {
            List<Point> points = new List<Point>();
            var dataDb = db.DataStation.ToList();

            foreach(var p in dataDb)
            {
                Point point = new Point();
                point.pointId = p.stationId;point.name = p.stationName;point.address = p.stationAdres;
                point.city = p.stationCity;point.country = p.stationCountry;
                point.lat = p.stationLatX;point.lng = p.stationLatY;
                point.typeId = int.Parse(p.stationTypeId.ToString());
                point.sektorName = getTypeName(int.Parse(p.stationTypeId.ToString()));
                points.Add(point);
            }
            return Json(
                new
                {
                    Result = from obj in points
                             select new
                             {
                                 obj.pointId,obj.name,obj.address,  obj.city, obj.country,obj.lat,  obj.lng,obj.typeId,obj.sektorName
                             }
                }, JsonRequestBehavior.AllowGet

              );
        }


       
        /// <summary>
        /// Akaryakıt türlerinin haritada listelenmesi
        /// </summary>
        /// <returns></returns>
        public JsonResult GetFuel()
        {
            List<Point> points = new List<Point>();
            var dataDb = db.FuelType.ToList();
            foreach (var p in dataDb)
            {
                Point point = new Point();
                point.pointId = p.fuelTypeId;
                point.name = p.fuelName;
                points.Add(point);
            }
            return Json(
                new
                {
                    Result = from obj in points
                             select new
                             {
                                 obj.pointId,
                                 obj.name,
                                 
                             }
                }, JsonRequestBehavior.AllowGet

              );
        }

       
        public string GetFuelPriceOrderByStation(List<string> rotaKoordinatlari,JsonString json)
        {
            List<Point> points = new List<Point>();
            HashSet<int> pointIds = new HashSet<int>();
            if (rotaKoordinatlari.Count > 0 && rotaKoordinatlari != null)
            {
                Dictionary<string, double> İkiKoordinatArasindakiNoktalar = new Dictionary<string, double>();

                for (int i = 0; i < rotaKoordinatlari.Count; i++)
                {
                    string[] splitter = rotaKoordinatlari[i].Split('-');
                    string lat = splitter[0];
                    string lng = splitter[1];
                    var stations = db.DataStation.ToList();
                    foreach (var item in stations)
                    {
                        if (İkiKoordinatArasindakiNoktalar.ContainsKey(item.stationId.ToString()))
                            continue;
                        double sonuc = StringHelper.UzaklikHesapla(lat, lng, item.stationLatX, item.stationLatY);
                        //Rota üzerindeki noktaları istasyonların yakınlık 
                        if (sonuc < 5)
                        {
                            İkiKoordinatArasindakiNoktalar.Add(item.stationId.ToString(), sonuc);
                        }
                    }
                }
                foreach (var stationKey in İkiKoordinatArasindakiNoktalar)
                {
                    int id = int.Parse(stationKey.Key);
                    var data = db.DataStation.Where(x => x.stationId == id).ToList();
                    foreach (var item in data)
                    {
                        var fuelPriceDb = db.FuelPrice.Where(x => x.stationTypeId == item.stationTypeId && x.fuelTypeId==json.id).ToList();
                        foreach(var fuel in fuelPriceDb)
                        {
                            if (pointIds.Contains(item.stationId))
                                continue;
                            pointIds.Add(item.stationId);
                            Point poly = new Point();
                            poly.pointId = item.stationId;
                            poly.name = item.stationName;
                            int cityIndex = StringHelper.getCityNumber(item.stationCity);
                            poly.city = item.stationCity;
                            poly.country = item.stationCountry;
                            int countryIndex = StringHelper.getCountryNumber(item.stationCountry);
                            poly.address = item.stationAdres;
                            poly.lat = item.stationLatX;
                            poly.lng = item.stationLatY;
                            poly.fuelPrice = getFuelPrice(cityIndex, countryIndex);
                            poly.sektorName = getTypeName(int.Parse(item.stationTypeId.ToString()));
                            points.Add(poly);
                        }

                    }
                }
            }

            return JsonConvert.SerializeObject(points);
        }



        /// <summary>
        /// Id bilgisine göre istasyon datasını gösterme
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetStation(JsonString location)
        {
            List<StationData> stations = new List<StationData>();

            var data = db.DataStation.Where(i => i.stationId == location.id).ToList();
            foreach (var item in data)
            {
                StationData station = new StationData();
                station.id = item.stationId;
                station.stationName = item.stationName;
                station.city = item.stationCity;
                station.country = item.stationCountry;
                station.adres = item.stationAdres;
                station.lat = item.stationLatX;
                station.lng = item.stationLatY;
                stations.Add(station);
            }
            return JsonConvert.SerializeObject(stations);
        }

        /// <summary>
        /// İki koordinat arasındaki istasyonları bulan method
        /// Minumum rotadaki koordinata 3 km yakın olanları al
        /// </summary>
        /// <returns></returns>
        public string TwoPointBeetweenStation(List<string> rotaKoordinatlari)
        {
            List<Point> ikiKoordinatArasiNoktalar = new List<Point>();
            if (rotaKoordinatlari.Count>0 && rotaKoordinatlari != null)
            {
                Dictionary<string, double> İkiKoordinatArasindakiNoktalar = new Dictionary<string, double>();
               
                for (int i = 0; i < rotaKoordinatlari.Count; i++)
                {
                    string[] splitter = rotaKoordinatlari[i].Split('-');
                    string lat = splitter[0];
                    string lng = splitter[1];
                    var stations = db.DataStation.ToList();
                    foreach (var item in stations)
                    {
                        if (İkiKoordinatArasindakiNoktalar.ContainsKey(item.stationId.ToString()))
                            continue;
                            double sonuc = StringHelper.UzaklikHesapla(lat, lng, item.stationLatX, item.stationLatY);
                        //Rota üzerindeki noktaları istasyonların yakınlık 
                        if (sonuc <4)
                        {
                            İkiKoordinatArasindakiNoktalar.Add(item.stationId.ToString(), sonuc);
                        }
                    }
                }
                foreach (var stationKey in İkiKoordinatArasindakiNoktalar)
                {
                    int id = int.Parse(stationKey.Key);
                    var data = db.DataStation.Where(x => x.stationId == id && (x.stationTypeId==1 || x.stationTypeId==2 || x.stationTypeId==3)).ToList();
                    foreach (var item in data)
                    {
                        Point poly = new Point();
                        poly.pointId = item.stationId;
                        poly. name = item.stationName;
                        int cityIndex = StringHelper.getCityNumber(item.stationCity);
                        poly.city = item.stationCity;
                        poly.country = item.stationCountry;
                        int countryIndex = StringHelper.getCountryNumber(item.stationCountry);
                        poly.address = item.stationAdres;
                        poly.lat = item.stationLatX;
                        poly.lng = item.stationLatY;
                        poly.fuelPrice = getFuelPrice(cityIndex, countryIndex);
                        poly.sektorName= getTypeName(int.Parse(item.stationTypeId.ToString()));
                        ikiKoordinatArasiNoktalar.Add(poly);
                    }
                }
            }
            else
            {

            }
            return JsonConvert.SerializeObject(ikiKoordinatArasiNoktalar);
        }

        /// <summary>
        /// Seçilen benzin istasyonunun akaryakıt tablosunu listeleme
        /// </summary>
        /// <param name="poly"></param>
        /// <returns></returns>
        public string getFuelTypeAndPrice(JsonString poly)
        {
            Point stationFuel = new Point();
            List<Point> stations = new List<Point>();
            var station= db.DataStation.Where(x => x.stationId == poly.id).FirstOrDefault();
            if (station != null)
            {
                int cityIndex = StringHelper.getCityNumber(station.stationCity);
                int countryIndex= StringHelper.getCountryNumber(station.stationCountry);
                stationFuel.fuelPrice= getFuelPrice(cityIndex, countryIndex);
                stations.Add(stationFuel);
            }
            return JsonConvert.SerializeObject(stations);
        }
        /// <summary>
        /// Konuma göre en yakın noktaları gösterme
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string NearestStationdData(JsonString location)
        {

            List<Point> points = new List<Point>();
            Dictionary<string, double> orderbyPoints = new Dictionary<string, double>();
            if (location != null) { 
                string[] splitter = location.data.Split('-');
                var StationPoints = db.DataStation.Where(x => x.stationTypeId == 1 || x.stationTypeId==2 || x.stationTypeId==3).ToList();
                foreach (var station in StationPoints)
                {
                    double sonuc = StringHelper.UzaklikHesapla(splitter[0], splitter[1], station.stationLatX,station.stationLatY);
                    orderbyPoints.Add(station.stationId.ToString(), sonuc);
                }
                var list = orderbyPoints.OrderBy(x => x.Value).Take(20);
                foreach (var key in list)
                {
                    int id = int.Parse(key.Key);
                    var data = db.DataStation.Where(x => x.stationId == id).ToList();
                    foreach (var item in data)
                    {
                        Point p = new Point();
                        p.pointId = item.stationId;
                        p.name = item.stationName;
                        p.address = item.stationAdres;
                        p.city = item.stationCity;
                        p.country = item.stationCountry;
                        p.lat = item.stationLatX;
                        p.lng = item.stationLatY;
                        p.sektorName = getTypeName(int.Parse(item.stationTypeId.ToString()));
                        points.Add(p);
                    }
                }
            }
            return JsonConvert.SerializeObject(points);
        }
        
        public string getFuelName(int fuelTypeId)
        {
            var fuelDb = db.FuelType.Where(x => x.fuelTypeId == fuelTypeId).FirstOrDefault();
            return fuelDb.fuelName;
        }

        public string getTypeName(int typeId)
        {
            var stationTypeDb = db.StationType.Where(x => x.stationTypeId == typeId).FirstOrDefault();
            return stationTypeDb.stationTypeName;
        }

        public List<FuelAndPrice>getFuelPrice(int cityNumber, int countryNumber)
        {
            List<FuelAndPrice> saveFuel = new List<FuelAndPrice>();
            var v = db.FuelPrice.Where(a => a.cityId == cityNumber && a.countryId == countryNumber).ToList();
            for(int i = 0; i < v.Count; i++)
            {
                FuelAndPrice fuel = new FuelAndPrice();
                fuel.fuelName = getFuelName(v[i].fuelTypeId);
                fuel.price = double.Parse(v[i].fuelPrice.ToString());
                saveFuel.Add(fuel);
            }
            if (v.Count==0)
            {
                var c = db.FuelPrice.Where(a => a.cityId == cityNumber).ToList();
                for(int j = 0; j < c.Count; j++)
                {
                    FuelAndPrice fuel = new FuelAndPrice();
                    fuel.fuelName = getFuelName(c[j].fuelTypeId);
                    fuel.price = double.Parse(c[j].fuelPrice.ToString());
                    saveFuel.Add(fuel);
                }
                var d = db.FuelPrice.Where(a => a.countryId == countryNumber).ToList();
                for (int j = 0; j < d.Count; j++)
                {
                    FuelAndPrice fuel = new FuelAndPrice();
                    fuel.fuelName = getFuelName(d[j].fuelTypeId);
                    fuel.price = double.Parse(d[j].fuelPrice.ToString());
                    saveFuel.Add(fuel);
                }
            }
            return saveFuel;
        }
        public string CatchmentAnalizi(Catchment catchment)
        {
            int distance = int.Parse(catchment.distance);
            List<Point> SectorPoints = new List<Point>();
            for(int i = 0; i < catchment.pointTypes.Length; i++)
            {
                int id = catchment.pointTypes[i];
                var poi = db.DataStation.Where(x => x.stationTypeId == id).ToList();
                foreach(var item in poi)
                {
                    Point p = new Point();
                    p.pointId = item.stationId;
                    p.name = item.stationName;
                    p.address = item.stationAdres;
                    p.city = item.stationCity;
                    p.country = item.stationCountry;
                    p.lat = item.stationLatX;
                    p.lng = item.stationLatY;
                    p.typeId = int.Parse(item.stationTypeId.ToString());
                    p.sektorName = getTypeName(int.Parse(item.stationTypeId.ToString()));
                    SectorPoints.Add(p);
                }
            }
            Dictionary<string, double> points = new Dictionary<string, double>();
            List<Point> stationPoint = new List<Point>();

            foreach (var item in SectorPoints)
            {
                double mesafe = StringHelper.UzaklikHesapla(catchment.lat, catchment.lng, item.lat, item.lng);
                if (mesafe<=distance)
                {
                    points.Add(item.pointId.ToString(), mesafe);
                }
            }
            foreach (var pointKey in points)
            {
                int id = int.Parse(pointKey.Key);
                var data = db.DataStation.Where(x => x.stationId == id).ToList();
                foreach (var item in data)
                {
                    Point poly = new Point();
                    poly.pointId = item.stationId;
                    poly.name = item.stationName;
                    poly.address = item.stationAdres;
                    poly.city = item.stationCity;
                    poly.country = item.stationCountry;
                    poly.lat = item.stationLatX;
                    poly.lng = item.stationLatY;
                    poly.sektorName = getTypeName(int.Parse(item.stationTypeId.ToString()));
                    stationPoint.Add(poly);
                }
            }
            return JsonConvert.SerializeObject(stationPoint);
        }
        public ActionResult LocationToStation()
        {
            return View();
        }
    }
    public class StationData
    {
        public int id { get; set; }
        public string stationName { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string adres { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}