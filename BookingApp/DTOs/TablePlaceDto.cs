using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.DTOs
{
    public class TablePlaceDto
    {
        public int Id { get; set; }

        public ICollection<BookingDto> Bookings { get; set; }
    }
}
