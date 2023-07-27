﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.EfCore.Concrete;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Fault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReportedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Faults");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Faulty product",
                            IsResolved = false,
                            ProductId = 2,
                            ReportedAt = new DateTime(2023, 7, 24, 15, 41, 49, 634, DateTimeKind.Local).AddTicks(220)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Faulty product",
                            IsResolved = false,
                            ProductId = 1,
                            ReportedAt = new DateTime(2023, 7, 24, 15, 41, 49, 634, DateTimeKind.Local).AddTicks(232)
                        });
                });

            modelBuilder.Entity("Entities.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 11,
                            EntityId = 1,
                            ImageData = new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 },
                            Name = "image_1"
                        },
                        new
                        {
                            Id = 12,
                            EntityId = 2,
                            ImageData = new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 },
                            Name = "image_2"
                        },
                        new
                        {
                            Id = 13,
                            EntityId = 3,
                            ImageData = new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 },
                            Name = "image_3"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Electronic",
                            Model = "Asus ZendBook",
                            Name = "Laptop",
                            Price = 999m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Electronic",
                            Model = "IPhone 14 Pro",
                            Name = "Phone",
                            Price = 999m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Book",
                            Model = "Clean Code",
                            Name = "Laptop",
                            Price = 100m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
