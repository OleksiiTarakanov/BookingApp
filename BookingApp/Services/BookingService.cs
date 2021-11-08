using AutoMapper;
using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Interfaces;
using BookingApp.Models;
using BookingApp.Unit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepository _bookingRepository;
        public BookingService(BookingAppDbContext context, IMapper mapper, IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> CreateBooking(BookingModel bookingModel)
        {
            var isBooked = await _bookingRepository.IsBooked(bookingModel);

            if (isBooked == true)
            {
                return new Response
                {
                    IsSuccess = false,
                    ErrorMessage = "You can not book this place for picked time"
                };
            }

            var booking = new Booking
            {
                UserId = bookingModel.UserId,
                TablePlaceId = bookingModel.TablePlaceId,
                Status = bookingModel.Status,
                BookingFrom = bookingModel.BookingFrom,
                BookingTo = bookingModel.BookingTo
            };

            _bookingRepository.CreateItem(booking);
            await _unitOfWork.Commit();

            _mapper.Map<BookingDto>(booking);
            return new Response
            {
                IsSuccess = true,
            };
        }

        public async Task<List<BookingDto>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAll();
            return _mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task<Response> DeleteBooking(int id)
        {
            var result = await _bookingRepository.DeleteBooking(id);
            if (result.IsSuccess)
            {
                await _unitOfWork.Commit();
            }

            return result;
        }

        public async Task<Response> UpdateBooking(BookingModel bookingModel)
        {
            var booking = new Booking
            {
                UserId = bookingModel.UserId,
                TablePlaceId = bookingModel.TablePlaceId,
                Status = bookingModel.Status,
                BookingFrom = bookingModel.BookingFrom,
                BookingTo = bookingModel.BookingTo
            };

            var result = await _bookingRepository.UpdateBooking(booking);
            if (result.IsSuccess)
            {
                await _unitOfWork.Commit();
            }

            return result;
        }
    }
}
