using BookingApp.Enums;
using BookingApp.Interfaces;
using BookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingApp.Controllers
{
    [Route("TableBooking")]
    [ApiController]
    public class TableBookingController : ControllerBase
    {
        private IBookingService _bookingService;
        public TableBookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("Bookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetAllBookings();
            return Ok(result);
        }

        [HttpGet("Bookings/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _bookingService.GeyById(id);
            return Ok(result);
        }

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingModel booking)
        {
            var result = await _bookingService.CreateBooking(booking);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            var result = await _bookingService.DeleteBooking(id);
            return Ok(result.ErrorMessage);
        }


        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingModel booking)
        {
            var result = await _bookingService.UpdateBooking(booking);
            return Ok(result.ErrorMessage);
        }

        [HttpPut("UpdateBookingStatus/{id}")]
        public async Task<IActionResult> UpdateBooking([FromRoute] int id, BookingStatus status)
        {
            var result = await _bookingService.UpdateBookingStatus(id, status);
            return Ok(result.ErrorMessage);
        }
    }
}
