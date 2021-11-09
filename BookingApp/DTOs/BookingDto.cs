using BookingApp.Classes;
using BookingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.DTOs
{
    public class BookingDto
    {
        public int BookingId { get; set; }

        public DateTime BookingFrom { get; set; }

        public DateTime BookingTo { get; set; }

        public Status Type { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public int UserId { get; set; }

        public int TablePlaceId { get; set; }
    }
}
