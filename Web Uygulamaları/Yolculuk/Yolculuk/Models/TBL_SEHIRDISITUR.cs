namespace Yolculuk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_SEHIRDISITUR
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(100)]
        public string baslik { get; set; }

        public string slider_bilgi { get; set; }

        public string slider_resim { get; set; }

        public int? il_id { get; set; }

        public virtual TBL_ILADLARI TBL_ILADLARI { get; set; }
    }
}
