namespace WebPdfOdev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ZiyaretciYorumu")]
    public partial class ZiyaretciYorumu
    {
        [Key]
        public int ziyaretciid { get; set; }

        [StringLength(50)]
        public string ziyaretciAdi { get; set; }

        [StringLength(50)]
        public string ziyaretciEmail { get; set; }

        public DateTime? Tarih { get; set; }

        [StringLength(500)]
        public string İcerik { get; set; }
    }
}
