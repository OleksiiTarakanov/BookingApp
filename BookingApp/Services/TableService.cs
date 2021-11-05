using AutoMapper;
using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Enums;
using BookingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    public class TableService : ITableService
    {
        private readonly BookingAppDbContext _context;
        private readonly IMapper _mapper;
        public TableService(BookingAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TablePlaceDto>> GetAllTablePlaces()
        {
            var result = await _context.Tables.Include(a => a.Bookings).ToListAsync();
            return _mapper.Map<List<TablePlaceDto>>(result);
        }

        public async Task<TablePlace> AddTablePlace(TablePlace place)
        {
            _context.Tables.Add(place);
            await _context.SaveChangesAsync();

            return place;
        }
    }
}
