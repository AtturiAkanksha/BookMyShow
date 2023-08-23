using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.Data.IRepositories;
using BookMyShow.DomainModels;

namespace BookMyShow.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IBaseRepository<Ticket> _baseTicketRepository;
        private readonly IBaseRepository<ReserveSeat> _baseSeatRepository;
        private readonly IMapper _mapper;

        public BookingRepository(IBaseRepository<Ticket> baseTicketRepository, IMapper mapper, IBaseRepository<ReserveSeat> baseSeatRepository)
        {
            _baseTicketRepository = baseTicketRepository;
            _mapper = mapper;
            _baseSeatRepository = baseSeatRepository;
        }

        public BookingRequest BookMovie(BookingRequest bookingRequest)
        {
            try
            {
                Ticket ticket = _mapper.Map<Ticket>(bookingRequest);
                List<ReserveSeat> SeatsList = bookingRequest.SeatNumbers.Select(Seats => new ReserveSeat
                {
                    SeatNumber = Seats,
                    TheatreId = bookingRequest.TheatreId,
                    MovieId = bookingRequest.MovieId,
                    ShowTime = bookingRequest.ShowTime
                }).ToList();
                _baseSeatRepository.AddList(SeatsList);
                return _mapper.Map<BookingRequest>(_baseTicketRepository.Add(ticket));
            }
            catch
            {
                throw;
            }
        }
    }
}
