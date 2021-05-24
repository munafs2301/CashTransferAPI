using CashTransferAPI.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashTransferAPI.Infrastructure.Services
{
    public class CashTransferAPIContext: DbContext
    {
        private readonly IConfiguration _config;

        public CashTransferAPIContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CashTransferAPI"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
              .HasData(new
              {
                  Reference = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                  Amount = 5000.98,
                  BalanceId = 1,
                  BeneficiaryAcccount = 0987654321
              },
              new
              {
                  Reference = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                  Amount = 5000.98,
                  BalanceId = 2,
                  BeneficiaryAcccount = 1234567890
              }
              );

            modelBuilder.Entity<Balance>()
              .HasData(new
              {
                  Id = 1,
                  AccountNumber = 1234567890,
                  AccountBalance = 5000.98,
              }, new 
              {
                  Id = 2,
                  AccountNumber = 0987654321,
                  AccountBalance = 10000.00,
              });      

        }
    }
}
