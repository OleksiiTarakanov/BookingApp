using AutoMapper;
using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Interfaces;
using BookingApp.Unit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITablePlacesRepository _tablePlacesRepository;
        public TableService(IMapper mapper, ITablePlacesRepository tablePlacesRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _tablePlacesRepository = tablePlacesRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<TablePlaceDto>> GetAllTablePlaces()
        {
            var result = await _tablePlacesRepository.GetAll();
            return _mapper.Map<List<TablePlaceDto>>(result);
        }

        public async Task<TablePlaceDto> AddTablePlace(TablePlace place)
        {
            var addedPlace = _tablePlacesRepository.CreateItem(place);
            await _unitOfWork.Commit();
            return _mapper.Map<TablePlaceDto>(addedPlace);
        }
    }
}
