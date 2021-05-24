using CashTransferAPI.Enitities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashTransferAPI.Data.Models
{
    public class TransactionModel
    {
        public string Reference { get; set; }

        [Required]
        public double Amount { get; set; }
        [Required]
        public int BeneficiaryAccount { get; set; }
        public int AccountNumber { get; set; }
        public Balance Balance { get; set; }

    }
}
