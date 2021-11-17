using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //GET: api/User/GetAllUsers
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            if (users is null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        //GET: api/User/GetUserById/{id}
        [Authorize]
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                return NotFound($"Item with the Id {id} was not found!");
            }
            return Ok(user);
        }

        //GET: api/User/GetUserByEmail/{email}
        [Authorize]
        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user is null)
            {
                return NotFound($"Item with the email {email} was not found!");
            }
            return Ok(user);
        }

        //GET: api/User/GetUsersByLastName/{lastName}
        [Authorize]
        [HttpGet]
        [Route("GetUsersByLastName/{lastName}")]
        public async Task<ActionResult> GetUsersByLastName(string lastName)
        {
            var user = await _userRepository.GetUsersByLastName(lastName);
            if (user is null)
            {
                return NotFound($"Item with the Lastname {lastName} was not found!");
            }
            return Ok(user);
        }

        //PUT: api/User/UpdateUser/{id}
        [Authorize]
        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, RegisterDto user)
        {
            if (id == 0)
            {
                return NotFound($"Item with the Id {id} was not found!");
            }

            var result = await _userRepository.UpdateUser(id, user);
            
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        //POST: api/User/DeleteUser/{id}
        [Authorize]
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUser(id);
            if (result is null)
            {
                return NotFound($"Item with the Id {id} was not found!");
            }
            return Ok(result);
        }
    }
       
}