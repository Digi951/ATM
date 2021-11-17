using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}