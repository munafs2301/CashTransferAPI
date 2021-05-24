using AutoMapper;
using CashTransferAPI.Data.Models;
using CashTransferAPI.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashTransferAPI.Infrastructure.Services
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionModel>()
               .ForMember(c => c.AccountNumber, o => o.MapFrom(m => m.Balance.AccountNumber))
               .ReverseMap();
               //.ForMember(m => m.Balance, o => o.Ignore());
        }

    }
}
