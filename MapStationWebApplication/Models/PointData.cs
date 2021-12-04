namespace StationShowApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PointData")]
    public partial class PointData
    {
        [Key]
        public int pointId { get; set; }

        [StringLength(200)]
        public string pointName { get; set; }

        [StringLength(500)]
        public string pointAddress { get; set; }

        [StringLength(200)]
        public string pointCity { get; set; }

        [StringLength(200)]
        public string pointDistrict { get; set; }

        [StringLength(100)]
        public string pointPhone { get; set; }

        [Required]
        [StringLength(10)]
        public string pointLat { get; set; }

        [Required]
        [StringLength(10)]
        public string pointLng { get; set; }

        public int pointTypeId { get; set; }

        [StringLength(50)]
        public string pointWriteType { get; set; }

        public DateTime? pointWriteDateTimeNow { get; set; }

        public int userId { get; set; }

        public virtual PointType PointType { get; set; }

        public virtual User User { get; set; }
    }
}
