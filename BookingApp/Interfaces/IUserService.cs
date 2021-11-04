using BookingApp.Classes;
using BookingApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookingApp.Controllers.UsersController;

namespace BookingApp.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetUsers();
        public Task<UserDto> CreateUser(UserModel user);
    }
}
