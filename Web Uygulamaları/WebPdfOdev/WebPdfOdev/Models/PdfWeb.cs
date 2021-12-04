namespace WebPdfOdev.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PdfWeb : DbContext
    {
        public PdfWeb()
            : base("name=PdfWeb")
        {
        }

        public virtual DbSet<Duyurular> Duyurular { get; set; }
        public virtual DbSet<OgretmenDersleri> OgretmenDersleri { get; set; }
        public virtual DbSet<PdfDokuman> PdfDokuman { get; set; }
        public virtual DbSet<PdfModel> PdfModel { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yetkisi> Yetkisi { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }
        public virtual DbSet<ZiyaretciYorumu> ZiyaretciYorumu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OgretmenDersleri>()
                .Property(e => e.derskodu)
                .IsUnicode(false);

            modelBuilder.Entity<OgretmenDersleri>()
                .Property(e => e.kullaniciadi)
                .IsUnicode(false);

            modelBuilder.Entity<PdfDokuman>()
                .Property(e => e.pdfAdi)
                .IsUnicode(false);

            modelBuilder.Entity<PdfDokuman>()
                .Property(e => e.pdfAciklama)
                .IsUnicode(false);

            modelBuilder.Entity<PdfDokuman>()
                .Property(e => e.pdfKonusu)
                .IsUnicode(false);

            modelBuilder.Entity<PdfDokuman>()
                .Property(e => e.pdfGonderenKisi)
                .IsUnicode(false);

            modelBuilder.Entity<PdfDokuman>()
                .Property(e => e.pdfYolu)
                .IsUnicode(false);

            modelBuilder.Entity<PdfModel>()
                .Property(e => e.pdfAdi)
                .IsUnicode(false);

            modelBuilder.Entity<PdfModel>()
                .Property(e => e.pdfKullanici)
                .IsUnicode(false);

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.OgretmenDersleri)
                .WithOptional(e => e.Uye)
                .HasForeignKey(e => e.uyeid);

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.Yorum)
                .WithOptional(e => e.Uye)
                .HasForeignKey(e => e.Uyeid);

            modelBuilder.Entity<Yetkisi>()
                .HasMany(e => e.Uye)
                .WithOptional(e => e.Yetkisi)
                .HasForeignKey(e => e.yetkiİd);

            modelBuilder.Entity<Yetkisi>()
                .HasMany(e => e.Yorum)
                .WithOptional(e => e.Yetkisi)
                .HasForeignKey(e => e.UyeYetki);
        }
    }
}
