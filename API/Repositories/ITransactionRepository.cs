using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using API.DTOs;

namespace API.Repositories
{
    public interface ITransactionRepository
    {
        Task<TransactionModel> GetTransactionById(int id);
        Task<IEnumerable<TransactionModel>> GetAllTransactions();
        Task<IEnumerable<TransactionModel>> GetTransactionsByDate(DateTime date);
        Task<IEnumerable<TransactionModel>> GetAllTransactionaByUser(int userId);
        Task<IEnumerable<TransactionModel>> GetTransactionsByUserAndDate(int userId, DateTime date);
        Task<TransactionModel> CreateTransaction(TransactionDto transaction);
        Task<TransactionModel> UpdateTransaction(TransactionDto transaction);
        Task<TransactionModel> DeleteTransaction(int id);
    }
}