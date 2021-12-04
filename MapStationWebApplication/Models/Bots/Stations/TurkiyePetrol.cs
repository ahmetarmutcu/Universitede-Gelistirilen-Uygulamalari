using Newtonsoft.Json;
using StationShowApplication.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationShowApplication.Models.Bots.Stations
{
    public class TurkiyePetrol
    {
       
        public static List<DataStation> getData()
        {
            StationDb db = new StationDb();
            List<Point> points = new List<Point>();
            string res = StringHelper.GetResponsive("http://www.tppd.com.tr/tr/stationlist?v=2");
            if (res != null)
            {
                var dataInfo = JsonConvert.DeserializeObject<List<TurkiyePetrolRootObject>>(res);
                if (dataInfo.Count > 0 && dataInfo != null)
                {
                    foreach (var item in dataInfo)
                    {
                        var yesNoControl = db.DataStation.Where(x => x.stationAdres == item.Address
                        && x.stationName == item.StationName).FirstOrDefault();
                        if (yesNoControl == null)
                        {
                            Point p = new Point();
                            p.name = item.StationName;
                            p.city = item.CityName;
                            p.country = item.County;
                            p.address = item.Address;
                            p.lat = item.Lat.ToString().Replace(",", ".");
                            p.lng = item.Lng.ToString().Replace(",", ".");
                            p.typeId = 1;
                            p.pointWriteType = "Otomatik";
                            p.pointWriteDateTime = DateTime.Now;
                            points.Add(p);
                        }

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
             return db.DataStation.ToList();
        }

        public static void getFuelPrice()
        {
            string city = "";
            StationDb db = new StationDb();
            HashSet<string> header = new HashSet<string>();
            List<FuelPriceList> fuelList = new List<FuelPriceList>();
            for (int i = 1; i <= 17; i++)
            {
                string baseUrl = "https://www.tppd.com.tr/tr/akaryakit-fiyatlari?id="+i;
                string res = StringHelper.GetResponsive(baseUrl);
                if(res!=null || res != "")
                {
                    string cityDiv = StringHelper.GetBetween(res, "<div class=\"col-sm-6\">", "</div>");
                    if (cityDiv != "")
                         city = StringHelper.GetBetween(cityDiv, "<h2>", "</h2>");
                    string table = StringHelper.GetBetween(res, "<table class=\"col-md-12 table table-bordered cf\">", "</table>");
                    if(table!=null && table != "")
                    {
                        string fuelHeader = StringHelper.GetBetween(res, "<thead class=\"cf\">", "</thead>");
                        if (fuelHeader != null)
                        {
                            string[] headers = StringHelper.GetLinesBetween(fuelHeader, "<th class=\"numeric\"");
                            if (headers != null)
                            {
                                for(int h = 1; h < headers.Length; h++)
                                {
                                    header.Add(StringHelper.GetBetween(headers[h], ">", "<"));
                                }

                            }
                        }


                        string fuelTable = StringHelper.GetBetween(table, "<tbody>", "</tbody>");
                        if (fuelHeader != "")
                        {
                            string[] rows = StringHelper.GetLinesBetween(fuelTable, "<tr>");
                            if(rows!=null)
                            {
                                for(int j = 2; j < rows.Length; j++)
                                {
                                    int cityId = StringHelper.getCityNumber(city);
                                    string country = StringHelper.GetBetween(rows[j], "<td data-title=\"İL&#199;E\">", "</td>");
                                    int countryId = StringHelper.getCountryNumber(country);
                                    string[] fuels = StringHelper.GetLinesBetween(rows[j], "<td data-title=");

                                    for(int f= 2;f< fuels.Length; f++)
                                    {
                                        string fuelName = StringHelper.GetBetween(fuels[f], "\"", "\"");
                                        int fuelId = StringHelper.getFuelPriceNumber(fuelName);
                                        string fuelPriceText= StringHelper.GetBetween(fuels[f], "class=\"numeric\">\r\n", "<").Trim();
                                        FuelPriceList fuel = new FuelPriceList();
                                        fuel.cityId = cityId;
                                        fuel.countryId = countryId;
                                        fuel.typeId = fuelId;
                                        fuel.fuelPrice = fuelPriceText;
                                        fuel.fuelWriteDateTime = DateTime.Now;
                                        fuelList.Add(fuel);
                                    }
                                        
                                }


                                }
                            }
                        }
                    }
                }

            foreach (var fuel in fuelList)
            {
                var control = db.FuelPrice.Where(x => x.cityId == fuel.cityId && x.countryId == fuel.countryId && x.fuelTypeId == fuel.typeId).FirstOrDefault();
                if (control==null)
                {
                    if (fuel.countryId != 0)
                    {
                        try
                        {
                            FuelPrice fuelItem = new FuelPrice();
                            fuelItem.cityId = fuel.cityId;
                            fuelItem.countryId = fuel.countryId;
                            fuelItem.fuelTypeId = fuel.typeId;
                            string fuelPrice = fuel.fuelPrice.ToString().Replace(".", ",");
                            fuelItem.fuelPrice = fuel.fuelPrice;
                            fuelItem.fuelWriteDateTimeNow = fuel.fuelWriteDateTime;
                            fuelItem.stationTypeId = 1;
                            db.FuelPrice.Add(fuelItem);
                            db.SaveChanges();
                        }
                        catch(Exception e)
                        {

                        }
                      
                    }
                    else
                    {

                    }
                }
            }
        }
    }
    public class TurkiyePetrolRootObject
    {
        public string StationName { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public string CityName { get; set; }
        public string Marker { get; set; }
        public bool VIS { get; set; }
    }
}