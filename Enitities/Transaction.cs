using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashTransferAPI.Enitities
{
    public class Transaction
    {
        [Key]
        public Guid Reference { get; set; }
        public double Amount { get; set; }

        public long BalanceId { get; set; }
        public Balance Balance { get; set; }
    }
}
