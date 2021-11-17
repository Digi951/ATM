using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _dataContext;

        public TransactionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactionsByUserId(int userId)
        {
            return await _dataContext.Transactions.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<TransactionModel>> GetAllTransactions()
        {
            return await _dataContext.Transactions.ToListAsync();
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

        public async Task<IEnumerable<TransactionModel>> GetTransactionsByDate(DateTime date)
        {
            return await _dataContext.Transactions.Where(x => x.CreatedAt == date).ToListAsync();
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactionsByUserIdAndDate(int userId, DateTime date)
        {
            return await _dataContext.Transactions.Where(x => x.UserId == userId && x.CreatedAt == date).ToListAsync();
        }

        public async Task<TransactionModel> CreateTransaction(TransactionDto transaction)
        {
            var user = await _dataContext.Users.FindAsync(transaction.UserId);

            if(user.Balance + transaction.Amount < -1000)
            {
                return null;
            }

            user.Balance += transaction.Amount;

            var result = new TransactionModel
            {
                UserId = transaction.UserId,
                Amount = transaction.Amount,
                CreatedAt = DateTime.UtcNow,
                Notice = transaction.Notice
            };

            _dataContext.Users.Update(user);
            await _dataContext.Transactions.AddAsync(result);
            await _dataContext.SaveChangesAsync();

            return result;
        }

        public async Task<TransactionModel> UpdateTransaction(int id, TransactionDto transaction)
        {
            var result = _dataContext.Transactions.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return null;
            }

            result.Amount = transaction.Amount;
            result.Notice = transaction.Notice;

            _dataContext.Transactions.Update(result);
            await _dataContext.SaveChangesAsync();

            return result;
        }
        public async Task<TransactionModel> DeleteTransaction(int id)
        {
            var result = _dataContext.Transactions.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            _dataContext.Transactions.Remove(result);
            await _dataContext.SaveChangesAsync();

            return result;
        }
    }
}