using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserById(int id);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUserByEmail(string email);
        Task<IEnumerable<UserModel>> GetUsersByLastName(string lastName);
        Task<UserModel> CreateUser(UserInputDto user);
        Task<UserModel> UpdateUser(int id, UserInputDto user);
        Task<UserModel> DeleteUser(int id);
    }
}