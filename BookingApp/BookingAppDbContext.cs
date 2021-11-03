using BookingApp.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp
{
    public class BookingAppDbContext : DbContext
    {
        public DbSet<TablePlace> Tables { get; set; }

        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablePlace>().HasKey(a => a.Id);
        }

    }
}
