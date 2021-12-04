namespace TelefonRehberi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Telefon : DbContext
    {
        public Telefon()
            : base("name=Telefon")
        {
        }

        public virtual DbSet<Calisanlar> Calisanlar { get; set; }
        public virtual DbSet<Departman> Departman { get; set; }
        public virtual DbSet<Yonetici> Yonetici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calisanlar>()
                .Property(e => e.Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Calisanlar>()
                .Property(e => e.Soyadi)
                .IsUnicode(false);

            modelBuilder.Entity<Calisanlar>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Calisanlar>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Calisanlar>()
                .Property(e => e.KullaniciAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Calisanlar>()
                .Property(e => e.Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Departman>()
                .Property(e => e.departmanadi)
                .IsUnicode(false);

            modelBuilder.Entity<Departman>()
                .HasMany(e => e.Calisanlar)
                .WithRequired(e => e.Departman)
                .HasForeignKey(e => e.Departmanid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yonetici>()
                .Property(e => e.yonetici1)
                .IsUnicode(false);

            modelBuilder.Entity<Yonetici>()
                .HasMany(e => e.Calisanlar)
                .WithRequired(e => e.Yonetici)
                .WillCascadeOnDelete(false);
        }
    }
}
