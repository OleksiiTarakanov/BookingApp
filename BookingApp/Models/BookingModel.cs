using BookingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    public class BookingModel
    {
        public DateTime BookingFrom { get; set; }

        public DateTime BookingTo { get; set; }

        public Status Status { get; set; }

        public int UserId { get; set; }

        public int TablePlaceId { get; set; }
    }
}
