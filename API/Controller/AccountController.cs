using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controller
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _dataContext;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext dataContext, ITokenService tokenService)
        {
            _dataContext = dataContext;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _dataContext.Users.AnyAsync(x => x.FirstName == registerDto.FirstName.ToLower() 
                                                    && x.LastName == registerDto.LastName.ToLower()))
            {
                return BadRequest("First name and last name already exists");
            }
            if (await _dataContext.Users.AnyAsync(x => x.Email == registerDto.Email.ToLower()))
            {
                return BadRequest("Email already exists");
            }

            using var hmac = new HMACSHA512();

            var user = new UserModel
            {
                FirstName = registerDto.FirstName.ToLower(),
                LastName = registerDto.LastName.ToLower(),
                Email = registerDto.Email.ToLower(),
                Balance = registerDto.Balance,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Balance = user.Balance,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _dataContext.Users
                                        .FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower() 
                                            || (x.FirstName == loginDto.FirstName.ToLower() && x.LastName == loginDto.LastName.ToLower()));

            if (user == null)
            {
                return Unauthorized("Invalid email or first name and last name");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid password");
                }
            }

            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Balance = user.Balance,
                Token = _tokenService.CreateToken(user)
            };
        }

    }
}