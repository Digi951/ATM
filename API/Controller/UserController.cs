using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
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

        //POST: api/User/CreateUser
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<UserInputDto>> CreateUser([FromBody] UserInputDto user)
        {
            if (user is null)
            {
                return BadRequest();
            }
            var result = await _userRepository.CreateUser(user);
            
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        //PUT: api/User/UpdateUser/{id}
        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, [FromBody] UserInputDto user)
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