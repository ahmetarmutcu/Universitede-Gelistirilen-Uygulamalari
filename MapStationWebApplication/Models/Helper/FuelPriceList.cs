using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationShowApplication.Models.Helper
{
    public class FuelPriceList
    {
        public int cityId { get; set; }
        public int countryId { get; set; }
        public int typeId { get; set; }
        public string fuelPrice { get; set; }
        public DateTime fuelWriteDateTime { get; set; }
          
    }
}