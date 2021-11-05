using AutoMapper;
using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Interfaces;
using BookingApp.Models;
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
        private readonly IMapper _mapper;
        public BookingService(BookingAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> CreateBooking(BookingModel bookingModel)
        {
            var bookingFromDb = await _context.Bookings.FirstOrDefaultAsync(i => (i.BookingFrom == bookingModel.BookingFrom || i.BookingTo == bookingModel.BookingTo) && i.TablePlaceId == bookingModel.TablePlaceId);

            if (bookingFromDb != null)
            {
                return new Response
                {
                    IsSuccess = false,
                    ErrorMessage = "You can not book this place for picked time"
                };
            }

            var booking = new Booking
            {
                UserId = bookingModel.UserId,
                TablePlaceId = bookingModel.TablePlaceId,
                Status = bookingModel.Status,
                BookingFrom = bookingModel.BookingFrom,
                BookingTo = bookingModel.BookingTo
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            _mapper.Map<BookingDto>(booking);
            return new Response
            {
                IsSuccess = true,
            };
        }

        public async Task<List<BookingDto>> GetAllBookings()
        {
            var bookings = await _context.Bookings.Include(a => a.User).ToListAsync();
            return _mapper.Map<List<BookingDto>>(bookings);
        }
    }
}
