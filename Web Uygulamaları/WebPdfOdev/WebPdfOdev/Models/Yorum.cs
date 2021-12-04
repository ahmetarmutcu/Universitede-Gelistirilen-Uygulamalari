namespace WebPdfOdev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int Yorumid { get; set; }

        [StringLength(500)]
        public string icerik { get; set; }

        public int? Uyeid { get; set; }

        public DateTime? Tarihi { get; set; }

        [StringLength(100)]
        public string uyeEmail { get; set; }

        public int? UyeYetki { get; set; }

        public virtual Uye Uye { get; set; }

        public virtual Yetkisi Yetkisi { get; set; }
    }
}
