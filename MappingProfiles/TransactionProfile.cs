using CashTransferAPI.Data.Models;
using CashTransferAPI.Enitities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashTransferAPI.MappingProfiles
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionModel>()
               .ForMember(c => c.AccountNumber, o => o.MapFrom(m => m.Balance.AccountNumber))
               .ReverseMap();
            //.ForMember(m => m.Balance, o => o.Ignore());
        }
    }
}
