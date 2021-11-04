using BookingApp.Classes;
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
        public TableService(BookingAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TablePlace>> GetAllTablePlaces()
        {
            var result = await _context.Tables.ToListAsync();
            return result;
        }

        public async Task<TablePlace> AddTablePlace(TablePlace place)
        {
            _context.Tables.Add(place);
            await _context.SaveChangesAsync();

            return place;
        }

        //public async Task<Response> UpdateTablePlaceStatus(int id, Status neededStatus)
        //{
        //    var tablePlace = await _context.Tables.Where(tablePlace => tablePlace.Id == id).SingleOrDefaultAsync();
        //    if (tablePlace.Status == Status.BookedPermanently)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            ErrorMessage = "Selected place is booked permanently"
        //        };
        //    }
        //    else if (neededStatus == tablePlace.Status)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            ErrorMessage = "Selected place is booked for selected day or part of day"
        //        };
        //    }
        //    else if (neededStatus == Status.BookedFullDay && (tablePlace.Status == Status.BookedFirstPartOfDay || tablePlace.Status == Status.BookedSecondPartOfDay))
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            ErrorMessage = "Selected place is booked for part of day"
        //        };
        //    } else
        //    {
        //        tablePlace.Status = neededStatus;
        //        await _context.SaveChangesAsync();
        //        return new Response
        //        {
        //            IsSuccess = true
        //        };
                
        //    }
        //}
    }
}
