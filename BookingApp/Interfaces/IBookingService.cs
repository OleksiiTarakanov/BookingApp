using BookingApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Interfaces
{
    public interface IBookingService
    {
        public Task<Response> CreateBooking(Booking booking);
        public Task<List<Booking>> GetAllBookings();
    }
}
