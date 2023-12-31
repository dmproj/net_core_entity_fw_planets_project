﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hikitocAPI.Data;

#nullable disable

namespace hikitocAPI.Migrations
{
    [DbContext(typeof(HikitocDbContext))]
    [Migration("20231123041354_Data Seed SolarSystems and Water")]
    partial class DataSeedSolarSystemsandWater
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hikitocAPI.Models.Domain.Planet", b =>
                {
                    b.Property<Guid>("PlanetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("DiameterKm")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("SolarSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlanetId");

                    b.HasIndex("SolarSystemId");

                    b.HasIndex("WaterId");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("hikitocAPI.Models.Domain.SolarSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Image")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("SolarSystems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1f4b631-0680-4d93-b2ed-deeb858cb930"),
                            Code = "SLRSYS",
                            Image = "image1.jpg",
                            Name = "Solar System"
                        },
                        new
                        {
                            Id = new Guid("fb336509-20ff-458b-8aa2-978090063fc0"),
                            Code = "TRPST1",
                            Image = "image2.jpg",
                            Name = "TRAPPIST-1"
                        });
                });

            modelBuilder.Entity("hikitocAPI.Models.Domain.Water", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Waters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89f3868e-f904-4976-bebe-1f6494ea2540"),
                            Image = "image1.jpg",
                            Type = "Liquid"
                        },
                        new
                        {
                            Id = new Guid("a1e7b1ae-164e-486e-9ec2-c208da0550e5"),
                            Image = "image2.jpg",
                            Type = "Ice"
                        },
                        new
                        {
                            Id = new Guid("8c7bc12b-34cf-4d09-8f36-4f34d30e15ff"),
                            Image = "image3.jpg",
                            Type = "Unknown"
                        });
                });

            modelBuilder.Entity("hikitocAPI.Models.Domain.Planet", b =>
                {
                    b.HasOne("hikitocAPI.Models.Domain.SolarSystem", "SolarSystem")
                        .WithMany()
                        .HasForeignKey("SolarSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hikitocAPI.Models.Domain.Water", "Water")
                        .WithMany()
                        .HasForeignKey("WaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SolarSystem");

                    b.Navigation("Water");
                });
#pragma warning restore 612, 618
        }
    }
}
