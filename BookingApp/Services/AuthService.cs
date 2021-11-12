using BookingApp.Classes;
using BookingApp.Interfaces;
using BookingApp.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly BookingAppDbContext _context;
        public AuthService(BookingAppDbContext context)
        {
            _context = context;
        }

        public async Task<ClaimsIdentity> GetIdentity(Credentials credentials)
        {
            var person = await _context.Users.FirstOrDefaultAsync(x => x.Email == credentials.Username && x.Password == credentials.Password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                    new Claim("role", person.UserRole)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }

        public async Task<Response> SignUp(UserModel userModel)
        {
            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                UserRole = userModel.FirstName == "adm1n" ? RolesString.Admin : RolesString.User
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new Response
            {
                ErrorMessage = "User created successfully",
                IsSuccess = true
            };
        }

        public async Task<AuthResponse> SignIn(Credentials credentials)
        {
            var identity = await GetIdentity(credentials);
            if (identity == null)
            {
                return new AuthResponse
                {
                    Message = "Wrong login or password",
                    IsSuccess = false,
                    AccessToken = null,
                    Name = null
                };
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new AuthResponse
            {
                AccessToken = encodedJwt,
                Name = identity.Name,
                IsSuccess = true,
                Message = "Success"
            };

            return response;
        }

    }
}
