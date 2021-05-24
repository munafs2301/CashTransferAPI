using CashTransferAPI.Data.Models;
using CashTransferAPI.Enitities;
using System;

namespace CashTransferAPI.Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        bool Delete(Guid reference);
        TransactionModel[] GetAllTransactions();
        Balance GetBalance(double accountNumber);
        TransactionModel GetTransaction(Guid reference);
        Transaction MakeTransfer(TransactionModel model, Balance user, Balance beneficiary);
    }
}