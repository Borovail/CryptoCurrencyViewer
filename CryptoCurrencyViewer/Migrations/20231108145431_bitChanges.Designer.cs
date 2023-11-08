﻿// <auto-generated />
using System;
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
    [Migration("20231108145431_bitChanges")]
    partial class bitChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.ConvertedLastInfo", b =>
                {
                    b.Property<int>("ConvertedLastInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConvertedLastInfoId"));

                    b.Property<decimal>("Usd")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ConvertedLastInfoId");

                    b.ToTable("ConvertedLastList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.ConvertedVolumeInfo", b =>
                {
                    b.Property<int>("ConvertedVolumeInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConvertedVolumeInfoId"));

                    b.Property<decimal>("Usd")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ConvertedVolumeInfoId");

                    b.ToTable("ConvertedVolumeList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.CryptoModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CryptoList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.DefaultCryptoModel", b =>
                {
                    b.Property<int>("DefaultCryptoModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DefaultCryptoModelId"));

                    b.Property<string>("CryptoModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<double?>("MarketCap")
                        .HasColumnType("float");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DefaultCryptoModelId");

                    b.HasIndex("CryptoModelName")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("DefaultCryptoList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.ExchangeHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CryptoModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SearchTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CryptoModelName");

                    b.HasIndex("UserId");

                    b.ToTable("ExchangeHistoryModel");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.ExtendedCryptoModel", b =>
                {
                    b.Property<int>("ExtendedCryptoModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExtendedCryptoModelId"));

                    b.Property<string>("CryptoModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("High24h")
                        .HasColumnType("float");

                    b.Property<double?>("Low24h")
                        .HasColumnType("float");

                    b.Property<double?>("MaxSupply")
                        .HasColumnType("float");

                    b.Property<double?>("PriceChangePercentage24h")
                        .HasColumnType("float");

                    b.Property<double?>("PriceChangePercentage7d")
                        .HasColumnType("float");

                    b.Property<double?>("TotalSupply")
                        .HasColumnType("float");

                    b.Property<double?>("Volume24h")
                        .HasColumnType("float");

                    b.HasKey("ExtendedCryptoModelId");

                    b.HasIndex("CryptoModelName")
                        .IsUnique();

                    b.ToTable("ExtendedCryptoList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.MarketCryptoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MarketList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.SearchHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CryptoModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SearchTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CryptoModelName");

                    b.HasIndex("UserId");

                    b.ToTable("SearchHistoryModel");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.TickerCryptoModel", b =>
                {
                    b.Property<int>("TickerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TickerId"));

                    b.Property<int>("ConvertedLastInfoId")
                        .HasColumnType("int");

                    b.Property<int>("ConvertedVolumeInfoId")
                        .HasColumnType("int");

                    b.Property<string>("CryptoModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("LastPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MarketId")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TickerId");

                    b.HasIndex("ConvertedLastInfoId");

                    b.HasIndex("ConvertedVolumeInfoId");

                    b.HasIndex("CryptoModelName");

                    b.HasIndex("MarketId");

                    b.ToTable("TickerCryptoList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("UsersList");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.DefaultCryptoModel", b =>
                {
                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.CryptoModel", "CryptoModel")
                        .WithOne("DefaultCryptoModel")
                        .HasForeignKey("CryptoCurrencyViewer.Models.Crypto.DefaultCryptoModel", "CryptoModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoCurrencyViewer.Models.UserModel", "User")
                        .WithMany("DefaultCryptos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CryptoModel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.ExchangeHistoryModel", b =>
                {
                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.CryptoModel", "Crypto")
                        .WithMany()
                        .HasForeignKey("CryptoModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoCurrencyViewer.Models.UserModel", "User")
                        .WithMany("ExchangeHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crypto");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.ExtendedCryptoModel", b =>
                {
                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.CryptoModel", "CryptoModel")
                        .WithOne("ExtendedCryptoModel")
                        .HasForeignKey("CryptoCurrencyViewer.Models.Crypto.ExtendedCryptoModel", "CryptoModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CryptoModel");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.SearchHistoryModel", b =>
                {
                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.CryptoModel", "Crypto")
                        .WithMany()
                        .HasForeignKey("CryptoModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoCurrencyViewer.Models.UserModel", "User")
                        .WithMany("SearchHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crypto");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.TickerCryptoModel", b =>
                {
                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.ConvertedLastInfo", "ConvertedLast")
                        .WithMany()
                        .HasForeignKey("ConvertedLastInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.ConvertedVolumeInfo", "ConvertedVolume")
                        .WithMany()
                        .HasForeignKey("ConvertedVolumeInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.CryptoModel", "CryptoModel")
                        .WithMany("TickerCryptoModels")
                        .HasForeignKey("CryptoModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoCurrencyViewer.Models.Crypto.MarketCryptoModel", "Market")
                        .WithMany("Tickers")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConvertedLast");

                    b.Navigation("ConvertedVolume");

                    b.Navigation("CryptoModel");

                    b.Navigation("Market");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.CryptoModel", b =>
                {
                    b.Navigation("DefaultCryptoModel")
                        .IsRequired();

                    b.Navigation("ExtendedCryptoModel")
                        .IsRequired();

                    b.Navigation("TickerCryptoModels");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.Crypto.MarketCryptoModel", b =>
                {
                    b.Navigation("Tickers");
                });

            modelBuilder.Entity("CryptoCurrencyViewer.Models.UserModel", b =>
                {
                    b.Navigation("DefaultCryptos");

                    b.Navigation("ExchangeHistory");

                    b.Navigation("SearchHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
