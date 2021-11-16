using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using API.DTOs;

namespace API.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _dataContext;

        public TransactionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public Task<TransactionModel> CreateTransaction(TransactionDto transaction)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionModel> DeleteTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionModel>> GetAllTransactionaByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionModel>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionModel> GetTransactionById(int id)
        {
            var result = await _dataContext.Transactions.FindAsync(id);

            if(result is null)
            {
                return null;
            }
            return result;
        }

        public Task<IEnumerable<TransactionModel>> GetTransactionsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionModel>> GetTransactionsByUserAndDate(int userId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionModel> UpdateTransaction(TransactionDto transaction)
        {
            throw new NotImplementedException();
        }
    }
}