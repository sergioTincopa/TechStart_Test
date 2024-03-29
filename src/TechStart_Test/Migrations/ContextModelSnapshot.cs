﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechStart_Test.DataBase;

namespace TechStart_Test.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechStart_Test.Models.Hospital", b =>
                {
                    b.Property<int>("IdHospital")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHospital");

                    b.ToTable("Hospital");
                });

            modelBuilder.Entity("TechStart_Test.Models.Item", b =>
                {
                    b.Property<int>("ItemNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdItemVendor")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemCost")
                        .HasPrecision(11, 3)
                        .HasColumnType("decimal(11,3)");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemVendorIdItemVendor")
                        .HasColumnType("int");

                    b.Property<decimal>("MinimunOrderQuantity")
                        .HasPrecision(11, 3)
                        .HasColumnType("decimal(11,3)");

                    b.Property<decimal>("PurchaseUnitMeasure")
                        .HasPrecision(11, 3)
                        .HasColumnType("decimal(11,3)");

                    b.Property<string>("UPC")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemNumber");

                    b.HasIndex("ItemVendorIdItemVendor");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("TechStart_Test.Models.ItemVendor", b =>
                {
                    b.Property<int>("IdItemVendor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdItemVendor");

                    b.ToTable("ItemVendor");
                });

            modelBuilder.Entity("TechStart_Test.Models.Pharmacy", b =>
                {
                    b.Property<int>("IdPharmacy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdHospital")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPharmacy");

                    b.ToTable("Pharmacy");
                });

            modelBuilder.Entity("TechStart_Test.Models.PharmacyInventory", b =>
                {
                    b.Property<int>("IdPharmacy")
                        .HasColumnType("int");

                    b.Property<int>("ItemNumber")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOnHand")
                        .HasColumnType("int");

                    b.Property<int>("ReorderQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SellingUnitMeasure")
                        .HasPrecision(11, 3)
                        .HasColumnType("decimal(11,3)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(11, 3)
                        .HasColumnType("decimal(11,3)");

                    b.HasKey("IdPharmacy", "ItemNumber");

                    b.ToTable("PharmacyInventory");
                });

            modelBuilder.Entity("TechStart_Test.Models.Item", b =>
                {
                    b.HasOne("TechStart_Test.Models.ItemVendor", "ItemVendor")
                        .WithMany()
                        .HasForeignKey("ItemVendorIdItemVendor");

                    b.Navigation("ItemVendor");
                });
#pragma warning restore 612, 618
        }
    }
}
