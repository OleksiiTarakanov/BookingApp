using BookingApp.Classes;
using BookingApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Controllers
{
    [Route("Tables")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("tablePlases")]
        public async Task<IActionResult> GetAllTablePlaces()
        {
            var TablePlacesList = await _tableService.GetAllTablePlaces();
            return Ok(TablePlacesList);
        }

        [HttpPost("tablePlace")]
        public async Task<IActionResult> AddTablePlace([FromForm] TablePlace place)
        {
            var res = await _tableService.AddTablePlace(place);
            return Ok(res);
        }
    }
}
