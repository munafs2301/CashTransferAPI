using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashTransferAPI.Enitities
{
    public class Balance
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public double AccountBalance { get; set; }
    }
}
