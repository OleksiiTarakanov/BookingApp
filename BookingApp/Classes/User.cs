using BookingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Classes
{
    public class User
    {
        public int UserId { get; private set; }

        public string UserRole { get; set; } = RolesString.User;

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
