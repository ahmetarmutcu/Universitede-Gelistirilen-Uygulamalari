namespace TelefonRehberi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calisanlar")]
    public partial class Calisanlar
    {
        public int id { get; set; }
        [Display(Name="Adi")]
        [Required(ErrorMessage ="Adýnýzý giriniz ")]
        [StringLength(20)]
        public string Adi { get; set; }
        [Display(Name = "Soyadý")]
        [Required(ErrorMessage = "Soyadýnýzý giriniz ")]
        [StringLength(20)]
        public string Soyadi { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
       
        [EmailAddress]
        public string email { get; set; }
        [StringLength(11,MinimumLength =11)]
        [Phone]
        [Display(Name = "Telefon Numarasý")]
        [Required(ErrorMessage = "Telefon Numarasýnýzý giriniz ")]

        public String Telefon { get; set; }

        [StringLength(50)]
        [Display(Name = "Kullanýcý Adý")]
        
        public string KullaniciAdi { get; set; }

        [StringLength(50)]
        [Display(Name = "Þifre")]
       
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Display(Name = "Kullanýcý Adý")]
        public int Departmanid { get; set; }

        [Display(Name = "Kullanýcý Adý")]
        public int Yoneticiid { get; set; }
        [Display(Name = "Kullanýcý Adý")]
        public virtual Departman Departman { get; set; }
        [Display(Name = "Kullanýcý Adý")]
        public virtual Yonetici Yonetici { get; set; }
    }
}
