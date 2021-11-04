using BookingApp.Classes;
using BookingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Interfaces
{
    public interface ITableService
    {
        public Task<List<TablePlace>> GetAllTablePlaces();
        public Task<TablePlace> AddTablePlace(TablePlace place);
        //public Task<Response> UpdateTablePlaceStatus(int id, Status neededStatus);
    }
}