using BookingApp.Classes;
using BookingApp.Enums;
using BookingApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userServise;
        public UsersController(IUserService userService)
        {
            _userServise = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userServise.GetUsers();
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel user)
        {
            var result = await _userServise.CreateUser(user);
            return Ok(result);
        }
    }
}
