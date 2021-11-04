using BookingApp.Classes;
using BookingApp.Enums;
using BookingApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            var result = await _bookingService.CreateBooking(booking);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }
    }
}
