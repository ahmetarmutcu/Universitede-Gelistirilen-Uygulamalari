namespace StationShowApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int userId { get; set; }

        [StringLength(10)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        [Required]
        [StringLength(10)]
        public string userName { get; set; }

        [Required]
        [StringLength(8)]
        public string userPassword { get; set; }

        public DateTime? userCreateDate { get; set; }

        public int? userRoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
