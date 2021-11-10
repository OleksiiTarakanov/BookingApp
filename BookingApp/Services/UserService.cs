using AutoMapper;
using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookingApp.Controllers.UsersController;

namespace BookingApp.Services
{
    public class UserService : IUserService
    {
        private readonly BookingAppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(BookingAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _context.Users.Include(a => a.Bookings).ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> CreateUser(UserModel userModel)
        {
            var user = new User
            {
                UserRole = RolesString.User,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);

        }
    }
}
