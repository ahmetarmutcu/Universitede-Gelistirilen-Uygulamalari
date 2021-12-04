namespace Yolculuk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ILADLARI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ILADLARI()
        {
            TBL_SEHIRDISITUR = new HashSet<TBL_SEHIRDISITUR>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int il_id { get; set; }

        [StringLength(20)]
        public string il_adi { get; set; }

        public string slider_anaresim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SEHIRDISITUR> TBL_SEHIRDISITUR { get; set; }
    }
}
