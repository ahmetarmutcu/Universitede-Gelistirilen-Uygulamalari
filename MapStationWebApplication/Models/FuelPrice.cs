namespace StationShowApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FuelPrice")]
    public partial class FuelPrice
    {
        public int fuelPriceId { get; set; }

        public int cityId { get; set; }

        public int countryId { get; set; }

        public int fuelTypeId { get; set; }

        [Column("fuelPrice")]
        [Required]
        [StringLength(10)]
        public string fuelPrice { get; set; }

        public DateTime fuelWriteDateTimeNow { get; set; }

        public int stationTypeId { get; set; }

        public virtual City City { get; set; }

        public virtual District District { get; set; }

        public virtual FuelType FuelType { get; set; }

        public virtual StationType StationType { get; set; }
    }
}
