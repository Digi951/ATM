using API.Model;

namespace API.Services
{
    public interface ITokenService
    {
        string CreateToken(UserModel user);
    }
}