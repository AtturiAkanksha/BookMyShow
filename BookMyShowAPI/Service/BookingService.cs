using AutoMapper;
using Data.DataModels;
using Data.IRepositories;
using DomainModels;
using Service.Contracts;

namespace Service
{
    public class BookingService : IBookingService
    {
        private readonly IBaseRepository<BookedShows> _DataRepository;
        private readonly IReservedSeatsService _reservedSeatsRepository;
        private readonly IMapper _mapper;

        public BookingService(IBaseRepository<BookedShows> repository, IMapper mapper, IReservedSeatsService reservedSeatsRepository)
        {
            _DataRepository = repository;
            _mapper = mapper;
            _reservedSeatsRepository = reservedSeatsRepository;
        }

        public async Task<BookingRequest> BookMovie(BookingRequest bookingRequest)
        {
            BookedShows _bookingRequest = _mapper.Map<BookedShows>(bookingRequest);
            List<Data.DataModels.ReservedSeats> seatsList = bookingRequest.SeatNames.Select(seat => new Data.DataModels.ReservedSeats
            {
                SeatNumber = seat,
                TheatreId = bookingRequest.TheatreId
            }).ToList();
            _reservedSeatsRepository.Add(seatsList);
            return _mapper.Map<BookingRequest>(_DataRepository.Add(_bookingRequest));
        }
    }
}
