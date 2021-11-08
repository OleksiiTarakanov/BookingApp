using BookingApp.Classes;
using BookingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class TablePlacesRepository : ITablePlacesRepository
    {
        private BookingAppDbContext _context;

        public TablePlacesRepository(BookingAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TablePlace>> GetAll()
        {
            var result = await _context.Tables.Include(a => a.Bookings).ToListAsync();
            return result;
        }

        public TablePlace CreateItem(TablePlace tablePlace)
        {
            _context.Tables.Add(tablePlace);
            return tablePlace;
        }
    }
}
