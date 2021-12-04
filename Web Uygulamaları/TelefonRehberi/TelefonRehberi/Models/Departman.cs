namespace TelefonRehberi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Departman")]
    public partial class Departman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departman()
        {
            Calisanlar = new HashSet<Calisanlar>();
        }

        [Key]
        public int departmanıd { get; set; }

        [StringLength(50)]
        [Display(Name ="Departman Bölümü ")]
        public string departmanadi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calisanlar> Calisanlar { get; set; }
    }
}
