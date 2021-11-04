using BookingApp.Classes;
using BookingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingAppDbContext _context;
        public BookingService(BookingAppDbContext context) 
        {
            _context = context;
        }

        public async Task<Response> CreateBooking(Booking booking)
        {
            var bookings = await _context.Bookings.ToListAsync();

            var bookingFromDb = await _context.Bookings.FirstOrDefaultAsync(i => (i.BookingFrom == booking.BookingFrom || i.BookingTo == booking.BookingTo) && i.TablePlaceId == booking.TablePlaceId);

                if(bookingFromDb != null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        ErrorMessage = "You can not book this place for picked time"
                    };
                }

                var result = _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                };
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            var result = await _context.Bookings.ToListAsync();
            return result;
        }
    }
}
