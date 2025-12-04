using System;
using Microsoft.EntityFrameworkCore;
using PersonInfoSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;


namespace PersonInfoSystem.Data;

public class PersonInfoDBContext : DbContext
{

    public DbSet<CityEntity> Cities { get; set; }
    public DbSet<CountryEntity> Countries { get; set; }
    public DbSet<AdressEntity> Adressies { get; set; }
    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<PersonAddressEntity> PersonAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var config = new ConfigurationBuilder()
        .AddUserSecrets<PersonInfoDBContext>()
        .Build();

        var connStr = config.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //CountryEntity
        modelBuilder.Entity<CountryEntity>(entity =>
        {
            entity.ToTable("Country");
            entity.HasKey(e => e.CountryId);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Continent).HasMaxLength(20);
            entity.Property(e => e.Currency).HasMaxLength(10);

            entity.HasMany(e => e.Cities)
            .WithOne(e => e.CountryNavigation)
            .HasForeignKey(e => e.CountryID)
            .OnDelete(DeleteBehavior.Cascade);
        });

        // CityEntity
        modelBuilder.Entity<CityEntity>(entity =>
        {
            entity.ToTable("City");
            entity.HasKey(e => e.CityID);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(e => e.CountryNavigation)
            .WithMany(e => e.Cities)
            .HasForeignKey(e => e.CountryID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Adressies)
            .WithOne(e => e.CityNavigation)
            .HasForeignKey(e => e.CityId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        //AdressEntity
        modelBuilder.Entity<AdressEntity>(entity =>
        {
            entity.ToTable("Adress");
            entity.HasKey(e => e.AdressId);
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(e => e.CityNavigation)
            .WithMany(e => e.Adressies)
            .HasForeignKey(e => e.CityId)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.PersonAdresses)
            .WithOne(e => e.Adress)
            .HasForeignKey(e => e.AdressId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        //PersonEntity
        modelBuilder.Entity<PersonEntity>(entity =>
        {
            entity.ToTable("Person");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.NationalID).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(10);

            entity.HasMany(e => e.PersonAdresses)
            .WithOne(e => e.Person)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        //PersonAdressEntity
        modelBuilder.Entity<PersonAddressEntity>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.AdressId });
            entity.HasOne(e => e.Person)
            .WithMany(e => e.PersonAdresses)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Adress)
            .WithMany(e => e.PersonAdresses)
            .HasForeignKey(e => e.AdressId)
            .OnDelete(DeleteBehavior.Cascade);

        });
    }

}