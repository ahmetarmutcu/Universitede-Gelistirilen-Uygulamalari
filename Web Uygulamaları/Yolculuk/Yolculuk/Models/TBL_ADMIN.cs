namespace Yolculuk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ADMIN
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(30)]
        public string kullaniciadi { get; set; }

        [StringLength(30)]
        public string sifre { get; set; }
    }
}
