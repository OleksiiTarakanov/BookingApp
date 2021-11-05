using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Interfaces
{
    public interface ITableService
    {
        public Task<List<TablePlaceDto>> GetAllTablePlaces();
        public Task<TablePlace> AddTablePlace(TablePlace place);
    }
}