using AutoMapper;
using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Enums;
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

            var days = (bookingModel.BookingTo - bookingModel.BookingFrom).TotalDays;

            var booking = new Booking
            {
                UserId = bookingModel.UserId,
                TablePlaceId = bookingModel.TablePlaceId,
                Type = bookingModel.Type,
                BookingFrom = bookingModel.BookingFrom,
                BookingTo = bookingModel.BookingTo,
                BookingStatus = days > 1 ? BookingStatus.Pending : BookingStatus.Approved
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

        public async Task<BookingDto> GeyById(int id)
        {
            var booking = await _bookingRepository.GetById(id);
            return _mapper.Map<BookingDto>(booking);
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
            var booking = await _bookingRepository.GetById(bookingModel.BookingId);
            booking.TablePlaceId = bookingModel.TablePlaceId;
            booking.Type = bookingModel.Type;
            booking.BookingFrom = bookingModel.BookingFrom;
            booking.BookingTo = bookingModel.BookingTo;

            var result = await _bookingRepository.UpdateBooking(booking);
            if (result.IsSuccess)
            {
                await _unitOfWork.Commit();
            }

            return result;
        }

        public async Task<Response> UpdateBookingStatus(int id, BookingStatus status)
        {
            var booking = await _bookingRepository.GetById(id);
            booking.BookingStatus = status;
            var result = await _bookingRepository.UpdateBooking(booking);
            if (result.IsSuccess)
            {
                await _unitOfWork.Commit();
            }

            return result;
        }
    }
}
