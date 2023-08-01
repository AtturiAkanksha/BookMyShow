using AutoMapper;
using Data.DataModels;
using Data.IRepositories;
using DomainModels;
using Service.Contracts;

namespace Service
{
    public class BookingService : IBookingService
    {
        private readonly IBaseRepository<BookedShow> _bookingRepository;
        private readonly IBaseRepository<Data.DataModels.ReservedSeat> _seatsRepository;
        private readonly IMapper _mapper;

        public BookingService(IBaseRepository<BookedShow> repository, IMapper mapper, IBaseRepository<Data.DataModels.ReservedSeat> seatsRepository)
        {
            _bookingRepository = repository;
            _mapper = mapper;
            _seatsRepository = seatsRepository;
        }

      

        public async Task<BookingRequest> BookMovie(BookingRequest bookingRequest)
        {
            BookedShow _bookingRequest = _mapper.Map<BookedShow>(bookingRequest);
            List<Data.DataModels.ReservedSeat> SeatsList = bookingRequest.SeatNames.Select(Seats => new Data.DataModels.ReservedSeat
            {
                SeatNumber = Seats,
                TheatreId = bookingRequest.TheatreId
            }).ToList();
            _seatsRepository.AddList(SeatsList);
            return _mapper.Map<BookingRequest>(_bookingRepository.Add(_bookingRequest));
        }
    }
}
