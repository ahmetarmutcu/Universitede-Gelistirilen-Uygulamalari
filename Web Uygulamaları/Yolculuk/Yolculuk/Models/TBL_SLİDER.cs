namespace Yolculuk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_SLİDER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(60)]
        public string buyuk_baslik { get; set; }

        [StringLength(100)]
        public string kısa_baslik { get; set; }

        [StringLength(500)]
        public string resim_yolu { get; set; }

        [StringLength(800)]
        public string resim_yonlendirme { get; set; }
    }
}
