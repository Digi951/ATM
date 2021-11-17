using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Model;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserById(int id);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUserByEmail(string email);
        Task<IEnumerable<UserModel>> GetUsersByLastName(string lastName);
        Task<UserModel> UpdateUser(int id, RegisterDto user);
        Task<UserModel> DeleteUser(int id);
    }
}