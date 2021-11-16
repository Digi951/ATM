using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserById(int id);
        Task<UserModel> GetAllUsers();
        Task<UserModel> GetUserByEmail(string email);
        Task<IEnumerable<UserModel>> GetUsersByLastName(string lastName);
        Task<UserModel> CreateUser(UserDto user);
        Task<UserModel> UpdateUser(UserDto user);
        Task<UserModel> DeleteUser(int id);
    }
}