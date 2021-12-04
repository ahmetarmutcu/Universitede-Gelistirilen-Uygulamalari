namespace StationShowApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StationDb : DbContext
    {
        public StationDb()
            : base("name=StationDb")
        {
        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<DataStation> DataStation { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<FuelPrice> FuelPrice { get; set; }
        public virtual DbSet<FuelType> FuelType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<StationType> StationType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.cityName)
                .IsFixedLength();

            modelBuilder.Entity<City>()
                .HasMany(e => e.District)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.FuelPrice)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationName)
                .IsUnicode(false);

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationAdres)
                .IsUnicode(false);

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationCity)
                .IsUnicode(false);

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationCountry)
                .IsUnicode(false);

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationPhone)
                .IsUnicode(false);

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationLatX)
                .IsFixedLength();

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationLatY)
                .IsFixedLength();

            modelBuilder.Entity<DataStation>()
                .Property(e => e.stationWriteType)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.districtName)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.FuelPrice)
                .WithRequired(e => e.District)
                .HasForeignKey(e => e.countryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FuelPrice>()
                .Property(e => e.fuelPrice)
                .IsUnicode(false);

            modelBuilder.Entity<FuelType>()
                .Property(e => e.fuelName)
                .IsUnicode(false);

            modelBuilder.Entity<FuelType>()
                .HasMany(e => e.FuelPrice)
                .WithRequired(e => e.FuelType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<StationType>()
                .Property(e => e.stationTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<StationType>()
                .Property(e => e.stationIconUrl)
                .IsUnicode(false);

            modelBuilder.Entity<StationType>()
                .HasMany(e => e.FuelPrice)
                .WithRequired(e => e.StationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userPassword)
                .IsUnicode(false);

            modelBuilder.Entity<StationType>()
          .HasMany(e => e.DataStation)
          .WithOptional(e => e.StationType)
          .HasForeignKey(e => e.stationTypeId);

            modelBuilder.Entity<Role>()
             .HasMany(e => e.User)
             .WithOptional(e => e.Role)
             .HasForeignKey(e => e.userRoleId);

            modelBuilder.Entity<StationType>()
             .HasMany(e => e.FuelPrice)
             .WithOptional(e => e.StationType)
             .HasForeignKey(e => e.stationTypeId);

        }
    }
}
