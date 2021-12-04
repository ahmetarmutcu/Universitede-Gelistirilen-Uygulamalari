namespace WebPdfOdev.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<OgretmenSecilenDersler> OgretmenSecilenDersler { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yetkisi> Yetkisi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yetkisi>()
                .HasMany(e => e.Uye)
                .WithOptional(e => e.Yetkisi)
                .HasForeignKey(e => e.yetkiİd);
        }
    }
}
