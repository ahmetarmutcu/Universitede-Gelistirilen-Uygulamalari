namespace WebPdfOdev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Duyurular")]
    public partial class Duyurular
    {
        [Key]
        public int duyuruid { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Modeller.Duyurular), Name = "duyuruadi")]

        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Duyurular), ErrorMessageResourceName = "reguired_duyuruaciklama")]

        public string duyuruadi { get; set; }

        [StringLength(200)]
        [Display(ResourceType = typeof(Resources.Modeller.Duyurular), Name = "duyuruaciklama")]

        [Required(ErrorMessageResourceType = typeof(Resources.Modeller.Duyurular), ErrorMessageResourceName = "reguired_duyuruaciklama")]
        public string duyuruAciklama { get; set; }
        [Display(ResourceType = typeof(Resources.Modeller.Duyurular), Name = "tarih")]
        public DateTime? duyuruTarihi { get; set; }
    }
}
