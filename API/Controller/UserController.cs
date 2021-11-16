using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        //GET: api/User/GetUserById/{id}
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //POST: api/User/CreateUser
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
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
    }
       
}