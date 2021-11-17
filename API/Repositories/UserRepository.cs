using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<UserModel>> GetUsersByLastName(string lastName)
        {
            return await _dataContext.Users.Where(x => x.LastName == lastName).ToListAsync();
        }

        public async Task<UserModel> UpdateUser(int id, RegisterDto user)
        {
            var result = await _dataContext.Users.FindAsync(id);

            if (result == null || user == null)
            {
                return null;
            }

            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.Email = user.Email;
            result.Balance = user.Balance;

            _dataContext.Users.Update(result);
            await _dataContext.SaveChangesAsync();

            return result;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var result = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            if (id == 0)
            {
                return null;
            }
         
            _dataContext.Users.Remove(result);
            await _dataContext.SaveChangesAsync();

            return result;
        }
    }
}