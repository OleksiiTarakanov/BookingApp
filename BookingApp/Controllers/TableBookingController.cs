using BookingApp.Classes;
using BookingApp.Enums;
using BookingApp.Interfaces;
using BookingApp.Models;
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


        [HttpPut("UpdateBooking/{bookingId}")]

        public async Task<IActionResult> UpdateBooking([FromBody] BookingModel booking, [FromRoute] int bookingId)
        {
            var result = await _bookingService.UpdateBooking(booking);
            return Ok(result.ErrorMessage);
        }
    }
}
