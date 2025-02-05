﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsPro.Models;


#nullable disable

namespace SportsPro.Migrations
{
    [DbContext(typeof(SportsProContext))]
    [Migration("20241103183931_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SportsPro.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "",
                            City = "San Francisco",
                            Country = "",
                            Email = "kanthoni@pge.com",
                            FirstName = "Kaitlyn",
                            LastName = "Anthoni",
                            PhoneNumber = "",
                            PostalCode = "",
                            State = ""
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "",
                            City = "Washington",
                            Country = "",
                            Email = "ania@mma.nidc.com",
                            FirstName = "Ania",
                            LastName = "Irvin",
                            PhoneNumber = "",
                            PostalCode = "",
                            State = ""
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "",
                            City = "Mission Viejo",
                            Country = "",
                            Email = "",
                            FirstName = "Gonzalo",
                            LastName = "Keeton",
                            PhoneNumber = "",
                            PostalCode = "",
                            State = ""
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "",
                            City = "Sacramento",
                            Country = "",
                            Email = "amauro@yahoo.org",
                            FirstName = "Anton",
                            LastName = "Mauro",
                            PhoneNumber = "",
                            PostalCode = "",
                            State = ""
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"));

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 1,
                            Description = "Program fails to install.",
                            OpenDate = new DateTime(2024, 11, 3, 10, 39, 31, 169, DateTimeKind.Local).AddTicks(5527),
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Could not install"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<double>("YearlyPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Code = "TRNY10",
                            Name = "Tournament Master 1.0",
                            ReleaseDate = new DateTime(2024, 11, 3, 10, 39, 31, 169, DateTimeKind.Local).AddTicks(5220),
                            YearlyPrice = 4.9900000000000002
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "alison@sportprosoftware.com",
                            Name = "Alison Diaz",
                            PhoneNumber = "800-555-0443"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "awilson@sportprosoftware.com",
                            Name = "Andrew Wilson",
                            PhoneNumber = "800-555-0449"
                        },
                        new
                        {
                            TechnicianId = 3,
                            Email = "gfiori@sportprosoftware.com",
                            Name = "Gina Fiori",
                            PhoneNumber = "800-555-0459"
                        },
                        new
                        {
                            TechnicianId = 4,
                            Email = "gunter@sportprosoftware.com",
                            Name = "Gunter Wendt",
                            PhoneNumber = "800-555-0400"
                        },
                        new
                        {
                            TechnicianId = 5,
                            Email = "jason@sportprosoftware.com",
                            Name = "Jason Lee",
                            PhoneNumber = "800-555-0440"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Incident", b =>
                {
                    b.HasOne("SportsPro.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
