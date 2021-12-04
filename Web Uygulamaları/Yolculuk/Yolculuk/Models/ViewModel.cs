using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yolculuk.Models
{
    public class ViewModel
    {
        public IEnumerable<TBL_SLİDER> TBL_SLİDER { get; set; }
        public IEnumerable<TBL_SEHIRDISITUR> TBL_SEHIRDISITUR { get; set; }
        public IEnumerable<TBL_ILADLARI> TBL_ILADLARI { get; set; }
    }
}