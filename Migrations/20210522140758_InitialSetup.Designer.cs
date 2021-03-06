// <auto-generated />
using System;
using CashTransferAPI.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashTransferAPI.Migrations
{
    [DbContext(typeof(CashTransferAPIContext))]
    [Migration("20210522140758_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<long>("AccountNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Balances");
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

                    b.HasKey("Reference");

                    b.HasIndex("BalanceId");

                    b.ToTable("Transactions");
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
