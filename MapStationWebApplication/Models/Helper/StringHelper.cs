using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace StationShowApplication.Models.Helper
{
    public class StringHelper
    {

        static StationDb db = new StationDb();
        public static string GetResponsive(string link)
        {
            string result = "";

            try
            {
                WebRequest request = HttpWebRequest.Create(link);
                Thread.Sleep(1000);
                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                 result = sr.ReadToEnd();
            }
           catch {
                result = "";
            }
            return result;
        }
        public static string GetBetween(string response, string begin, string end = null) // Get Between
        {
            string[] splitter = new string[1];
            splitter[0] = begin;
            var resSplit = response.Split(splitter, StringSplitOptions.None);
            if (resSplit == null || resSplit.Length <= 1)
                return string.Empty;
            string responsePart = resSplit[1];
            if (end == null)
                return responsePart;
            splitter[0] = end;
            return responsePart.Split(splitter, StringSplitOptions.None)[0];
        }
        public static string[] GetLinesBetween(string response, string split) // Get Lines Between
        {
            string[] splitter = new string[1];
            splitter[0] = split;
            string[] splittedList = response.Split(splitter, StringSplitOptions.None);
            return splittedList;
        }

        public string PostRequest(string link,string postData)
        {
            

            WebRequest request = WebRequest.Create(link);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string res = reader.ReadToEnd();
            return res;


        }
        public static int getCityNumber(string city)
        {
            int id =1;
            var cityDb = db.City.ToList();
            for(int i = 0; i < cityDb.Count; i++)
            {
                if (city.ToUpper().Contains(cityDb[i].cityName.Trim()))
                {
                    id= cityDb[i].cityId;
                    break;
                }
                else if (city == cityDb[i].cityName.Trim())
                {
                    id = cityDb[i].cityId;
                    break;
                }
                else { }
            }
            return id;
           
        }
        public static int getCountryNumber(string district)
        {
            int districtId = 0;
            var districtDb = db.District.ToList();
            for(int i = 0; i < districtDb.Count; i++)
            {
                if (district.ToUpper().Contains(districtDb[i].districtName.Trim()))
                {
                    districtId = districtDb[i].districtId;
                    break;
                }
                else if (district == districtDb[i].districtName.Trim())
                {
                    districtId = districtDb[i].districtId;
                    break;
                }
                else { }
            }
            return districtId;
        }
        public static int getFuelPriceNumber(string fuelType)
        {
            var fuelDb = db.FuelType.Where(x => x.fuelName.ToString() == fuelType.ToString()).FirstOrDefault();
            return fuelDb.fuelTypeId;
        }

        public static  double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        public static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        public static double UzaklikHesapla(string enlem1, string boylam1, string enlem2, string boylam2)
        {
            enlem1 = enlem1.Replace(".", ",");
            boylam1 = boylam1.Replace(".", ",");
            enlem2 = enlem2.Replace(".", ",");
            boylam2 = boylam2.Replace(".", ",");
            double locationX = Math.Round(double.Parse(enlem1), 2);
            double locationY = Math.Round(double.Parse(boylam1), 2);

            double getlocationX = Math.Round(double.Parse(enlem2), 2);
            double getlocationY = Math.Round(double.Parse(boylam2), 2);
            double tetaDegeri = locationY - getlocationY;
            double mil = Math.Sin(deg2rad(locationX)) * Math.Sin(deg2rad(getlocationX)) +
                Math.Cos(deg2rad(locationX)) * Math.Cos(deg2rad(getlocationX)) * Math.Cos(deg2rad(tetaDegeri));
            mil = Math.Acos(mil);
            mil = rad2deg(mil);
            mil = mil * 60 * 1.1515;
            double kilometre = mil * 1.609344;
            return kilometre;
        }

    }
}