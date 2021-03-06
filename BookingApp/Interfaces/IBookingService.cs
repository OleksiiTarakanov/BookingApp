using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Interfaces
{
    public interface IBookingService
    {
        public Task<Response> CreateBooking(BookingModel booking);
        public Task<List<BookingDto>> GetAllBookings();
        public Task<Response> DeleteBooking(int id);
        public Task<Response> UpdateBooking(BookingModel booking);
        public Task<BookingDto> GeyById(int id);
        public Task<Response> UpdateBookingStatus(int id, Enums.BookingStatus status);
    }
}
