namespace WebPdfOdev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Uye")]
    public partial class Uye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uye()
        {
            OgretmenDersleri = new HashSet<OgretmenDersleri>();
            Yorum = new HashSet<Yorum>();
        }

        [Key]
        public int uyeİd { get; set; }
        [Display(ResourceType = typeof(Resources.Modeller.Uye),Name = "adi")]

        [Required(ErrorMessageResourceType =typeof(Resources.Modeller.Uye),ErrorMessageResourceName = "reguired_adi")]
        [StringLength(20)]
        public string uyeAd { get; set; }
        [Display(ResourceType = typeof(Resources.Modeller.Uye), Name = "soyadi")]
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Uye), ErrorMessageResourceName = "reguired_soyadi")]
        [StringLength(20)]
        public string uyeSoyad { get; set; }
        [Display(ResourceType = typeof(Resources.Modeller.Uye), Name = "kullanıcı")]
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Uye), ErrorMessageResourceName = "reguired_kullanıcı")]

        [StringLength(50)]
        public string Kullanaciadi { get; set; }
        [Display(ResourceType = typeof(Resources.Modeller.Uye), Name = "email")]
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Uye), ErrorMessageResourceName = "reguired_email")]
        [StringLength(50)]
        [EmailAddress]
        
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Modeller.Uye), Name = "sifre")]
        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Uye), ErrorMessageResourceName = "reguirde_sifre")]
        [StringLength(50)]
      
        public string Sifre { get; set; }
        
        public int? yetkiİd { get; set; }
       
        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Modeller.Uye), Name = "sifretekrarı")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Sifre",ErrorMessageResourceType = typeof(Resources.Modeller.Uye), ErrorMessageResourceName = "reguired_sifretekrarı")]
        public string SifreTekrarı { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OgretmenDersleri> OgretmenDersleri { get; set; }
        [Display(ResourceType = typeof(Resources.Modeller.Uye), Name = "seciniz")]


        public virtual Yetkisi Yetkisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}
