using BookingApp.Enums;
using System;

namespace BookingApp.Classes
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime BookingFrom { get; set; }

        public DateTime BookingTo { get; set; }

        public Status Type { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public TablePlace TablePlace { get; set; }

        public int TablePlaceId { get; set; }
    }
}
