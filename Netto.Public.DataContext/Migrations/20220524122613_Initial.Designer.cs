﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Netto.Public.DataContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Netto.Public.DataContext.Migrations
{
    [DbContext(typeof(PublicDbContext))]
    [Migration("20220524122613_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Netto.Public.DataContext.Entities.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BankAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("GeoLat")
                        .HasColumnType("double precision");

                    b.Property<double>("GeoLong")
                        .HasColumnType("double precision");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Country")
                        .IsUnique();

                    b.HasIndex("TypeId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.BankType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.ContactPhones", b =>
                {
                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("CardsSupport")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ForIndividuals")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Country");

                    b.ToTable("ClientStatusCodes");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.Extras", b =>
                {
                    b.Property<Guid>("BankId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Consultation")
                        .HasColumnType("boolean");

                    b.Property<bool>("ExoticExchange")
                        .HasColumnType("boolean");

                    b.Property<bool>("Insurance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Pandus")
                        .HasColumnType("boolean");

                    b.HasKey("BankId");

                    b.ToTable("PassportDatas");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.Popular", b =>
                {
                    b.Property<Guid>("BankId")
                        .HasColumnType("uuid");

                    b.Property<bool>("CurrencyExchange")
                        .HasColumnType("boolean");

                    b.Property<bool>("Payments")
                        .HasColumnType("boolean");

                    b.Property<bool>("TopUp")
                        .HasColumnType("boolean");

                    b.Property<bool>("TopUpWithoutCard")
                        .HasColumnType("boolean");

                    b.Property<bool>("Transfer")
                        .HasColumnType("boolean");

                    b.Property<bool>("WithdrawCard")
                        .HasColumnType("boolean");

                    b.HasKey("BankId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.WorkingHours", b =>
                {
                    b.Property<Guid>("BankId")
                        .HasColumnType("uuid");

                    b.Property<bool>("AllTime")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("date");

                    b.Property<bool>("OpenNow")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("date");

                    b.Property<bool>("Weekends")
                        .HasColumnType("boolean");

                    b.HasKey("BankId");

                    b.ToTable("UserSecurities");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.Bank", b =>
                {
                    b.HasOne("Netto.Public.DataContext.Entities.ContactPhones", "ContactPhones")
                        .WithOne("Bank")
                        .HasForeignKey("Netto.Public.DataContext.Entities.Bank", "Country")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Netto.Public.DataContext.Entities.BankType", "BankType")
                        .WithOne("Bank")
                        .HasForeignKey("Netto.Public.DataContext.Entities.Bank", "TypeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("BankType");

                    b.Navigation("ContactPhones");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.Extras", b =>
                {
                    b.HasOne("Netto.Public.DataContext.Entities.Bank", "Bank")
                        .WithOne("Extras")
                        .HasForeignKey("Netto.Public.DataContext.Entities.Extras", "BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.Popular", b =>
                {
                    b.HasOne("Netto.Public.DataContext.Entities.Bank", "Bank")
                        .WithOne("Popular")
                        .HasForeignKey("Netto.Public.DataContext.Entities.Popular", "BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.WorkingHours", b =>
                {
                    b.HasOne("Netto.Public.DataContext.Entities.Bank", "Bank")
                        .WithOne("WorkingHours")
                        .HasForeignKey("Netto.Public.DataContext.Entities.WorkingHours", "BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.Bank", b =>
                {
                    b.Navigation("Extras")
                        .IsRequired();

                    b.Navigation("Popular")
                        .IsRequired();

                    b.Navigation("WorkingHours")
                        .IsRequired();
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.BankType", b =>
                {
                    b.Navigation("Bank")
                        .IsRequired();
                });

            modelBuilder.Entity("Netto.Public.DataContext.Entities.ContactPhones", b =>
                {
                    b.Navigation("Bank")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
