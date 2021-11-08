
using BookingApp.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp
{
    public class UnitOfWork : IUnitOfWork 
    {
        private BookingAppDbContext _context;

        public UnitOfWork(BookingAppDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
