﻿// <auto-generated />
using System;
using Interview_BasicCRUD.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Interview_BasicCRUD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201124085548_UpdateProduct_Add_DB_TRDAT_2")]
    partial class UpdateProduct_Add_DB_TRDAT_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Interview_BasicCRUD.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DB_CRDAT")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DB_TRDAT")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<double?>("DiscountPrice")
                        .HasColumnType("REAL");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}