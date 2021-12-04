using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationShowApplication.Models.Helper
{
    public class Catchment
    {
        public string lat { get; set; }
        public string lng { get; set; }
        public string distance { get; set; }
        public int[] pointTypes { get; set; }
    }
}