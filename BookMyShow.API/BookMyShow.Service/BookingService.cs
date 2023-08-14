using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.Data.IRepositories;
using BookMyShow.DomainModels;
using BookMyShow.Services.Contracts;

namespace BookMyShow.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBaseRepository<BookedShow> _bookingRepository;
        private readonly IBaseRepository<Data.DataModels.ReserveSeat> _seatsRepository;
        private readonly IMapper _mapper;

        public BookingService(IBaseRepository<BookedShow> repository, IMapper mapper, IBaseRepository<Data.DataModels.ReserveSeat> seatsRepository)
        {
            _bookingRepository = repository;
            _mapper = mapper;
            _seatsRepository = seatsRepository;
        }

        public BookingRequest BookMovie(BookingRequest bookingRequest)
        {
            try
            {
                BookedShow _bookingRequest = _mapper.Map<BookedShow>(bookingRequest);
                List<Data.DataModels.ReserveSeat> SeatsList = bookingRequest.SeatNumbers.Select(Seats => new Data.DataModels.ReserveSeat
                {
                    SeatNumber = Seats,
                    TheatreId = bookingRequest.TheatreId,
                    MovieTime = bookingRequest.MovieTimings
                }).ToList();
                _seatsRepository.AddList(SeatsList);
                //unnecassary mapping
                return  _mapper.Map<BookingRequest>(_bookingRepository.Add(_bookingRequest));
            }
            catch
            {
                throw;
            }
        }
    }
}
