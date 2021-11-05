using BookingApp.Classes;
using BookingApp.DTOs;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablePlace>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<TablePlace>()
                .HasMany(a => a.Bookings)
                .WithOne(a => a.TablePlace);

            modelBuilder.Entity<User>()
                .HasKey(a => a.UserId);

            modelBuilder.Entity<Booking>()
                .HasKey(a => a.BookingId);

            modelBuilder.Entity<Booking>()
                .HasOne(a => a.User)
                .WithMany(a => a.Bookings);
        }

    }
}
