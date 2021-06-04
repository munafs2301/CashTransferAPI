using AutoMapper;
using CashTransferAPI.Data.Contexts;
using CashTransferAPI.Data.Models;
using CashTransferAPI.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashTransferAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository , IDisposable
    {
        private readonly CashTransferAPIContext _context;
        private readonly IMapper _mapper;

        public TransactionRepository(CashTransferAPIContext cashTransferAPIContext, IMapper mapper)
        {
            _context = cashTransferAPIContext;
            _mapper = mapper;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public TransactionModel[] GetAllTransactions()
        {
            var transactions = _context.Transactions.Include(m => m.Balance).ToArray().OrderByDescending(m => m.Amount);
            var transactionModels = _mapper.Map<TransactionModel[]>(transactions);
            return transactionModels;
        }
         public TransactionModel GetTransaction(Guid reference)
        {
            var transaction = _context.Transactions.Include(m => m.Balance).FirstOrDefault(m => m.Reference == reference);
            var transactionModel = _mapper.Map<TransactionModel>(transaction);
            return transactionModel;
        }

        public Balance GetBalance(double accountNumber)
        {
            var balance = _context.Balances.FirstOrDefault(m => m.AccountNumber == accountNumber);
            return balance;
        }

        public async Task<Transaction> MakeTransfer(TransactionModel model, Balance user, Balance beneficiary)
        {
            model.Reference = Guid.NewGuid().ToString("N");
            user.AccountBalance -= model.Amount;
            beneficiary.AccountBalance += model.Amount;
            model.Balance = user;

            var transaction = _mapper.Map<Transaction>(model);

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public bool Delete(Guid reference)
        {
            var transaction = _context.Transactions.FirstOrDefault(m => m.Reference == reference);
            if (transaction == null) return false;
            var result = _context.Transactions.Remove(transaction);
            _context.SaveChanges();
            return true;
        }
    }
}
