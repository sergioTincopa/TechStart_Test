using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TechStart_Test.Models;

namespace TechStart_Test.DataBase
{
    public class Context : DbContext
    {

        public DbSet<Item> Item { get; set; }
        public DbSet<ItemVendor> ItemVendor { get; set; }
        public DbSet<PharmacyInventory> PharmacyInventory { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Hospital> Hospital { get; set; }

        public Context([NotNullAttribute] DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            //only development
            //if (true)
            //{
            //    optionsBuilder.EnableDetailedErrors()
            //       .EnableSensitiveDataLogging()
            //       .LogTo(Console.WriteLine, LogLevel.Information);

            //}


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(entity => {
                entity.HasKey(e => e.ItemNumber);
                entity.Property(e => e.ItemNumber).ValueGeneratedOnAdd();
                entity.Property(e => e.MinimunOrderQuantity).HasPrecision(11, 3);
                entity.Property(e => e.PurchaseUnitMeasure).HasPrecision(11, 3);
                entity.Property(e => e.ItemCost).HasPrecision(11, 3);

                entity.HasOne(e => e.ItemVendor)
                .WithMany(x => x.ListItem).HasForeignKey(e => e.IdItemVendor);


                //entity.Property(e => e.UPC).HasColumnType("varchar(12)");
            });

            modelBuilder.Entity<ItemVendor>(entity => {
                entity.HasKey(e => e.IdItemVendor);
                entity.Property(e => e.IdItemVendor).ValueGeneratedOnAdd();

                
            });

            modelBuilder.Entity<PharmacyInventory>(entity => {
                entity.HasKey(e => new { e.IdPharmacy , e.ItemNumber});
                entity.Property(e => e.UnitPrice).HasPrecision(11, 3);
                entity.Property(e => e.SellingUnitMeasure).HasPrecision(11, 3);


            });

            modelBuilder.Entity<Pharmacy>(entity => {
                entity.HasKey(e => e.IdPharmacy);
                entity.Property(e => e.IdPharmacy).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Hospital>(entity => {
                entity.HasKey(e => e.IdHospital);
                entity.Property(e => e.IdHospital).ValueGeneratedOnAdd();
            });

        }

    }


}
