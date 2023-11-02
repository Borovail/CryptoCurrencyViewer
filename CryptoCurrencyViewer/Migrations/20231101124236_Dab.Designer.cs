﻿// <auto-generated />
using CryptoCurrencyViewer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231101124236_Dab")]
    partial class Dab
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CryptoCurrencyViewer.Models.CryptoModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("High24h")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Low24h")
                        .HasColumnType("float");

                    b.Property<double>("MarketCap")
                        .HasColumnType("float");

                    b.Property<double>("MaxSupply")
                        .HasColumnType("float");

                    b.Property<double>("PriceChangePercentage24h")
                        .HasColumnType("float");

                    b.Property<double>("PriceChangePercentage7d")
                        .HasColumnType("float");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalSupply")
                        .HasColumnType("float");

                    b.Property<double>("Volume24h")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("CryptoList");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CryptoModel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.SearchHistoryModel", b =>
                {
                    b.HasBaseType("CryptoCurrencyViewer.Models.CryptoModel");

                    b.HasDiscriminator().HasValue("SearchHistoryModel");
                });
#pragma warning restore 612, 618
        }
    }
}
