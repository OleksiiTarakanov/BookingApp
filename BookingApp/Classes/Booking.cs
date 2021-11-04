using BookingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Classes
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime BookingFrom { get; set; }

        public DateTime BookingTo { get; set; }

        public Status Status { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public TablePlace TablePlace { get; set; }

        public int TablePlaceId { get; set; }
    }
}
