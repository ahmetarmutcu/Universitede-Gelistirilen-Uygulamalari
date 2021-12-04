namespace WebPdfOdev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PdfDokuman")]
    public partial class PdfDokuman
    {
        [Key]
        public int ıd { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "reguired_dokuman")]
        [StringLength(20, ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "dokumanharf", MinimumLength = 5)]
        [Display(ResourceType = typeof(Resources.Modeller.Dokuman), Name = "dokumanadi")]
        public string pdfAdi { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "reguired_aciklama")]
        [StringLength(500,  ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "aciklama_harf", MinimumLength = 10)]
        [Display(ResourceType = typeof(Resources.Modeller.Dokuman), Name = "dokumanaciklama")]
        public string pdfAciklama { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "reguired_konu")]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "konu_harf", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Modeller.Dokuman), Name = "konu")]
        public string pdfKonusu { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "reguired_Tarih")]
        [Display(ResourceType = typeof(Resources.Modeller.Dokuman), Name = "Tarih")]
        public DateTime? pdfTarihi { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "reguired_gonderen")]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources.Modeller.Dokuman), ErrorMessageResourceName = "konu_harf", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Modeller.Dokuman), Name = "gonderen")]
        public string pdfGonderenKisi { get; set; }
       

            [StringLength(500)]
        [Display(ResourceType = typeof(Resources.Modeller.Dokuman), Name = "dosyaseciniz")]

        public string pdfYolu { get; set; }
    }
}
