using System;
using Domain.Models;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Data
{
    public class RentalDbContext : DbContext
    {
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Product> Product { get; set; }
        
        public RentalDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .HasMany<Product>(x => x.Products)
                .WithOne();

            modelBuilder.Entity<Purchase>()
                .HasMany<Product>(x => x.PurchasedProducts)
                .WithOne();
        }
    }
}