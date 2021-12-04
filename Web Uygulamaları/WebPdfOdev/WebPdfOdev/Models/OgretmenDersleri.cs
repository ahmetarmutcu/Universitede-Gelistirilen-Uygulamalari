namespace WebPdfOdev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OgretmenDersleri")]
    public partial class OgretmenDersleri
    {
        public int id { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Modeller.DosyaYönetim), Name = "derskodu")]

        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.DosyaYönetim), ErrorMessageResourceName = "required_derskodu")]
        public string derskodu { get; set; }

        public int? uyeid { get; set; }

        [StringLength(500)]
        [Display(ResourceType = typeof(Resources.Modeller.DosyaYönetim), Name = "ogretmenkullanici")]

       
        public string kullaniciadi { get; set; }

        public virtual Uye Uye { get; set; }
    }
}
