using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //context : veritabanı ile proje kodlarını ilişkelendirir
    public class ReCapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCap;Trusted_Connection=true"); 
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>().ToTable("Cars");
        //    modelBuilder.Entity<Car>().Property(c => c.CarId).HasColumnName("Id");
        //    modelBuilder.Entity<Car>().Property(c => c.BrandId).HasColumnName("BrandId");
        //    modelBuilder.Entity<Car>().Property(c => c.ColorId).HasColumnName("ColorId");
        //    modelBuilder.Entity<Car>().Property(c => c.ModelYear).HasColumnName("ModelYear");
        //    modelBuilder.Entity<Car>().Property(c => c.DailyPrice).HasColumnName("DailyPrice");
        //    modelBuilder.Entity<Car>().Property(c => c.Description).HasColumnName("Description");

        //    modelBuilder.Entity<Brand>().ToTable("Brands");
        //    modelBuilder.Entity<Brand>().Property(c => c.BrandId).HasColumnName("Id");
        //    modelBuilder.Entity<Brand>().Property(c => c.BrandName).HasColumnName("Name");

        //    modelBuilder.Entity<Color>().ToTable("Colors");
        //    modelBuilder.Entity<Color>().Property(c => c.ColorId).HasColumnName("Id");
        //    modelBuilder.Entity<Color>().Property(c => c.ColorName).HasColumnName("Name");
        //}
    }
}
