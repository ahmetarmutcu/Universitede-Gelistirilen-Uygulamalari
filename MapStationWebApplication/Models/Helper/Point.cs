using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationShowApplication.Models.Helper
{
    public class Point
    {
        public int pointId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public int typeId { get; set; }
        public string sektorName { get; set; }
        public string pointWriteType { get; set; }
        public List<FuelAndPrice> fuelPrice;
        public DateTime pointWriteDateTime { get; set; }
    }
}