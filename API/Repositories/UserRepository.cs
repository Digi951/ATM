using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<UserModel> CreateUser(UserDto user)
        {
            var userModel = new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedOn = DateTime.UtcNow,
                Balance = user.Balance
            };

            await _dataContext.Users.AddAsync(userModel);
            await _dataContext.SaveChangesAsync();

            return userModel;
        }

        public Task<UserModel> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var result = await _dataContext.Users.FindAsync(id);
            return result;
        }

        public Task<IEnumerable<UserModel>> GetUsersByLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}