using BookingApp.Classes;
using BookingApp.Interfaces;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private BookingAppDbContext _context;

        public BookingRepository(BookingAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Booking>> GetAll()
        {
            var result = await _context.Bookings.Include(a => a.User).ToListAsync();
            return result;
        }

        public async Task<bool> IsBooked(BookingModel booking)
        {
            var bookingFromDb = await _context.Bookings.AnyAsync(i => (i.BookingFrom == booking.BookingFrom || i.BookingTo == booking.BookingTo) && i.TablePlaceId == booking.TablePlaceId);
            return bookingFromDb;  
        }

        public Booking CreateItem(Booking booking)
        {
            _context.Bookings.Add(booking);
            return booking;
        }

        public async Task<Response> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(i => i.BookingId == id);

            if (booking == null)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorMessage = "Error"
                };
            }
                _context.Bookings.Remove(booking);
            
            return new Response()
            {
                IsSuccess = true,
                ErrorMessage = "Success"
            };
        }

        public async Task<Response> UpdateBooking(Booking booking)
        {
            var bookingFromDb = await _context.Bookings.FirstOrDefaultAsync(i => i.BookingId == booking.BookingId);

            if (booking == null)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorMessage = "Error"
                };
            }

            _context.Bookings.Update(booking);

            return new Response()
            {
                IsSuccess = true,
                ErrorMessage = "Success"
            };

        }
    }
}
