using BookingApp.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingApp.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponse> SignIn(Credentials credentials);
        public Task<ClaimsIdentity> GetIdentity(Credentials credentials);
        public Task<Response> SignUp(UserModel userModel);
    }
}
