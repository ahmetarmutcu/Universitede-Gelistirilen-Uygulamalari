namespace StationShowApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataStation")]
    public partial class DataStation
    {
        [Key]
        public int stationId { get; set; }

        [StringLength(500)]
        public string stationName { get; set; }

        [StringLength(1000)]
        public string stationAdres { get; set; }

        [Required]
        [StringLength(200)]
        public string stationCity { get; set; }

        [StringLength(200)]
        public string stationCountry { get; set; }

        [StringLength(11)]
        public string stationPhone { get; set; }

        [StringLength(10)]
        public string stationLatX { get; set; }

        [StringLength(10)]
        public string stationLatY { get; set; }

        public int? stationTypeId { get; set; }

        [StringLength(100)]
        public string stationWriteType { get; set; }

        public DateTime? stationWriteDateTime { get; set; }

        public virtual StationType StationType { get; set; }
    }
}
