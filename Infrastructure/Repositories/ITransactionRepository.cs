using CashTransferAPI.Data.Models;
using CashTransferAPI.Enitities;
using System;
using System.Threading.Tasks;

namespace CashTransferAPI.Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        bool Delete(Guid reference);
        TransactionModel[] GetAllTransactions();
        Balance GetBalance(double accountNumber);
        TransactionModel GetTransaction(Guid reference);
        Task<Transaction> MakeTransfer(TransactionModel model, Balance user, Balance beneficiary);
    }
}