namespace WebPdfOdev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PdfModel")]
    public partial class PdfModel
    {
        [Key]
        public int ıd { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "reguired_dokuman")]
        [StringLength(200)]
        public string pdfAdi { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "dosyaseciniz")]
        [StringLength(250)]
        public string pdfYolu { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "reguired_aciklama")]
        public string pdfAciklama { get; set; }

        [StringLength(100)]
        [Display(ResourceType = typeof(Resources.Modeller.DosyaYönetim), Name = "ogretmenkullanici")]

        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.DosyaYönetim), ErrorMessageResourceName = "required_ogretmenkullanici")]
        public string pdfKullanici { get; set; }

        public int? pdfuyeid { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Modeller.DosyaYönetim), Name = "derskodu")]

        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.DosyaYönetim), ErrorMessageResourceName = "required_derskodu")]
        public string pdfDerskodu { get; set; }
       
        public DateTime? pdfTarihi { get; set; }
    }
}
