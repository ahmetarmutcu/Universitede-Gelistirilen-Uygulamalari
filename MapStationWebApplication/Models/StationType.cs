namespace StationShowApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StationType")]
    public partial class StationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StationType()
        {
            DataStation = new HashSet<DataStation>();
            FuelPrice = new HashSet<FuelPrice>();
        }

        public int stationTypeId { get; set; }

        [StringLength(100)]
        public string stationTypeName { get; set; }

        [StringLength(300)]
        public string stationIconUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataStation> DataStation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuelPrice> FuelPrice { get; set; }
    }
}
