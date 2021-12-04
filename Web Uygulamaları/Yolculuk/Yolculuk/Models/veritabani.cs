namespace Yolculuk.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class veritabani : DbContext
    {
        public veritabani()
            : base("name=veritabani")
        {
        }

        public virtual DbSet<TBL_ADMIN> TBL_ADMIN { get; set; }
        public virtual DbSet<TBL_HIZMETLER> TBL_HIZMETLER { get; set; }
        public virtual DbSet<TBL_ILADLARI> TBL_ILADLARI { get; set; }
        public virtual DbSet<TBL_ISTANBULTURU> TBL_ISTANBULTURU { get; set; }
        public virtual DbSet<TBL_SEHIRDISITUR> TBL_SEHIRDISITUR { get; set; }
        public virtual DbSet<TBL_SLİDER> TBL_SLİDER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_ADMIN>()
                .Property(e => e.kullaniciadi)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ADMIN>()
                .Property(e => e.sifre)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_HIZMETLER>()
                .Property(e => e.baslik)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_HIZMETLER>()
                .Property(e => e.resimadi)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_HIZMETLER>()
                .Property(e => e.resimyonlendirme)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ILADLARI>()
                .Property(e => e.il_adi)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ILADLARI>()
                .Property(e => e.slider_anaresim)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ISTANBULTURU>()
                .Property(e => e.baslik)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ISTANBULTURU>()
                .Property(e => e.resimadi)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_SEHIRDISITUR>()
                .Property(e => e.baslik)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_SEHIRDISITUR>()
                .Property(e => e.slider_bilgi)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_SEHIRDISITUR>()
                .Property(e => e.slider_resim)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_SLİDER>()
                .Property(e => e.buyuk_baslik)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_SLİDER>()
                .Property(e => e.kısa_baslik)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_SLİDER>()
                .Property(e => e.resim_yolu)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_SLİDER>()
                .Property(e => e.resim_yonlendirme)
                .IsUnicode(false);
        }
    }
}
