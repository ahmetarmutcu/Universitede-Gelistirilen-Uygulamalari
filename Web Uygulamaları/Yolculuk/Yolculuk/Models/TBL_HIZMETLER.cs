namespace Yolculuk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_HIZMETLER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(500)]
        public string baslik { get; set; }

        public string resimadi { get; set; }

        [StringLength(400)]
        public string resimyonlendirme { get; set; }
    }
}
