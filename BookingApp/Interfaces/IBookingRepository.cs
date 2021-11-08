using BookingApp.Classes;
using BookingApp.Models;
using System.Threading.Tasks;

namespace BookingApp.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        public Task<bool> IsBooked(BookingModel booking);

        public Task<Response> DeleteBooking(int id);

        public Task<Response> UpdateBooking(Booking booking);
    }
}
