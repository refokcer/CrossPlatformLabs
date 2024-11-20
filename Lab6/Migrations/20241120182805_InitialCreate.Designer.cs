﻿// <auto-generated />
using System;
using Lab6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab6.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241120182805_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Lab6.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrandDetails")
                        .HasColumnType("TEXT");

                    b.Property<string>("BrandName")
                        .HasColumnType("TEXT");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Lab6.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CarManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarManufacturerNr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarModel")
                        .HasColumnType("TEXT");

                    b.Property<int>("CarYearOfManufacture")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherCarDetails")
                        .HasColumnType("TEXT");

                    b.HasKey("CarId");

                    b.HasIndex("CarManufacturerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Lab6.Models.CarManufacturer", b =>
                {
                    b.Property<int>("CarManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarManufacturerName")
                        .HasColumnType("TEXT");

                    b.HasKey("CarManufacturerId");

                    b.ToTable("CarManufacturers");
                });

            modelBuilder.Entity("Lab6.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IndividualFirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("IndividualLastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("IndividualMiddleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherDetails")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerStatusId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab6.Models.CustomerStatus", b =>
                {
                    b.Property<int>("CustomerStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerStatusId");

                    b.ToTable("CustomerStatuses");
                });

            modelBuilder.Entity("Lab6.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("OrderAmountDue")
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherDetails")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Lab6.Models.Part", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MainSupplierName")
                        .HasColumnType("TEXT");

                    b.Property<int>("MainSupplierNr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherPartDetails")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartGroupID")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartMakerCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PartMakerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartTypeCode")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PriceToCustomer")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PriceToUs")
                        .HasColumnType("TEXT");

                    b.HasKey("PartId");

                    b.HasIndex("BrandId");

                    b.HasIndex("PartMakerId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Lab6.Models.PartInOrder", b =>
                {
                    b.Property<int>("PartInOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ActualSalesPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartSupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartSupplierPartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartSupplierSupplierNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("PartInOrderId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PartSupplierPartId", "PartSupplierSupplierNr");

                    b.ToTable("PartsInOrders");
                });

            modelBuilder.Entity("Lab6.Models.PartMaker", b =>
                {
                    b.Property<int>("PartMakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartMakerCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartMakerName")
                        .HasColumnType("TEXT");

                    b.HasKey("PartMakerId");

                    b.ToTable("PartMakers");
                });

            modelBuilder.Entity("Lab6.Models.PartSupplier", b =>
                {
                    b.Property<int>("PartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SupplierNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartSupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PartId", "SupplierNr");

                    b.HasIndex("SupplierId");

                    b.ToTable("PartSuppliers");
                });

            modelBuilder.Entity("Lab6.Models.PartsForCar", b =>
                {
                    b.Property<int>("PartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PartId", "CarId");

                    b.HasIndex("CarId");

                    b.ToTable("PartsForCars");
                });

            modelBuilder.Entity("Lab6.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("County")
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherDetails")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Town")
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Lab6.Models.Car", b =>
                {
                    b.HasOne("Lab6.Models.CarManufacturer", "CarManufacturer")
                        .WithMany("Cars")
                        .HasForeignKey("CarManufacturerId");

                    b.Navigation("CarManufacturer");
                });

            modelBuilder.Entity("Lab6.Models.Customer", b =>
                {
                    b.HasOne("Lab6.Models.CustomerStatus", "CustomerStatus")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerStatusId");

                    b.Navigation("CustomerStatus");
                });

            modelBuilder.Entity("Lab6.Models.Order", b =>
                {
                    b.HasOne("Lab6.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Lab6.Models.Part", b =>
                {
                    b.HasOne("Lab6.Models.Brand", "Brand")
                        .WithMany("Parts")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.PartMaker", "PartMaker")
                        .WithMany("Parts")
                        .HasForeignKey("PartMakerId");

                    b.Navigation("Brand");

                    b.Navigation("PartMaker");
                });

            modelBuilder.Entity("Lab6.Models.PartInOrder", b =>
                {
                    b.HasOne("Lab6.Models.Order", "Order")
                        .WithMany("PartsInOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.PartSupplier", "PartSupplier")
                        .WithMany()
                        .HasForeignKey("PartSupplierPartId", "PartSupplierSupplierNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PartSupplier");
                });

            modelBuilder.Entity("Lab6.Models.PartSupplier", b =>
                {
                    b.HasOne("Lab6.Models.Part", "Part")
                        .WithMany("PartSuppliers")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Supplier", "Supplier")
                        .WithMany("PartSuppliers")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Part");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Lab6.Models.PartsForCar", b =>
                {
                    b.HasOne("Lab6.Models.Car", "Car")
                        .WithMany("PartsForCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Lab6.Models.Brand", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Lab6.Models.Car", b =>
                {
                    b.Navigation("PartsForCars");
                });

            modelBuilder.Entity("Lab6.Models.CarManufacturer", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Lab6.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Lab6.Models.CustomerStatus", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Lab6.Models.Order", b =>
                {
                    b.Navigation("PartsInOrders");
                });

            modelBuilder.Entity("Lab6.Models.Part", b =>
                {
                    b.Navigation("PartSuppliers");
                });

            modelBuilder.Entity("Lab6.Models.PartMaker", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Lab6.Models.Supplier", b =>
                {
                    b.Navigation("PartSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
