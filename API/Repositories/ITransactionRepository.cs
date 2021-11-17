using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Model;

namespace API.Repositories
{
    public interface ITransactionRepository
    {
        Task<TransactionModel> GetTransactionById(int id);
        Task<IEnumerable<TransactionModel>> GetAllTransactions();
        Task<IEnumerable<TransactionModel>> GetTransactionsByDate(DateTime date);
        Task<IEnumerable<TransactionModel>> GetTransactionsByUserId(int userId);
        Task<IEnumerable<TransactionModel>> GetTransactionsByUserIdAndDate(int userId, DateTime date);
        Task<TransactionModel> CreateTransaction(TransactionDto transaction);
        Task<TransactionModel> UpdateTransaction(int id, TransactionDto transaction);
        Task<TransactionModel> DeleteTransaction(int id);
    }
}