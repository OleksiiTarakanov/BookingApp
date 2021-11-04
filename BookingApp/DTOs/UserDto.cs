using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.DTOs
{
    public class UserDto
    {
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UserId { get; set; }
    }
}
