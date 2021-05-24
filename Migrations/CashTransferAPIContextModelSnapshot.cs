﻿// <auto-generated />
using System;
using CashTransferAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashTransferAPI.Migrations
{
    [DbContext(typeof(CashTransferAPIContext))]
    partial class CashTransferAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashTransferAPI.Enitities.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Balances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountBalance = 5000.9799999999996,
                            AccountNumber = 1234567890
                        },
                        new
                        {
                            Id = 2,
                            AccountBalance = 10000.0,
                            AccountNumber = 987654321
                        });
                });

            modelBuilder.Entity("CashTransferAPI.Enitities.Transaction", b =>
                {
                    b.Property<Guid>("Reference")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("BalanceId")
                        .HasColumnType("int");

                    b.Property<int>("BeneficiaryAcccount")
                        .HasColumnType("int");

                    b.HasKey("Reference");

                    b.HasIndex("BalanceId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Reference = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Amount = 5000.9799999999996,
                            BalanceId = 1,
                            BeneficiaryAcccount = 987654321
                        },
                        new
                        {
                            Reference = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Amount = 5000.9799999999996,
                            BalanceId = 2,
                            BeneficiaryAcccount = 1234567890
                        });
                });

            modelBuilder.Entity("CashTransferAPI.Enitities.Transaction", b =>
                {
                    b.HasOne("CashTransferAPI.Enitities.Balance", "Balance")
                        .WithMany()
                        .HasForeignKey("BalanceId");
                });
#pragma warning restore 612, 618
        }
    }
}
