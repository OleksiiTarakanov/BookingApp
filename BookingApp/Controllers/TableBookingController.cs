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
        private ITableBookingService _tableBookingService;
        private readonly BookingAppDbContext _context;
        public TableBookingController(BookingAppDbContext context, ITableBookingService tableBookingService)
        {
            _context = context;
            _tableBookingService = tableBookingService;
        }

        [HttpGet("tablePlases")]
        public async Task<IActionResult> GetAllTablePlaces()
        {
            var TablePlacesList =  await _tableBookingService.GetAllTablePlaces();
            return Ok(TablePlacesList);
        }

        [HttpPost("tablePlace")]
        public async Task<IActionResult> AddTablePlace([FromForm] TablePlace place)
        {
            var res = await _tableBookingService.AddTablePlace(place);
            return Ok(res);
        }

        [HttpPut("tablePlace/{tablePlaceId}/status")]
        public async Task<IActionResult> UpdateTablePlaceStatus([FromRoute] int tablePlaceId, Status neededStatus)
        {
            var result = await _tableBookingService.UpdateTablePlaceStatus(tablePlaceId, neededStatus);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }

    }
}
