using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.Data.IRepositories;
using BookMyShow.DomainModels;
using BookMyShow.Services.Contracts;
using Repository;

namespace BookMyShow.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBaseRepository<Ticket> _baseRepository;
        private readonly IBaseRepository<ReserveSeat> _baseSeatsRepository;
        private readonly IMapper _mapper;

        public BookingService(IBaseRepository<Ticket> baseRepository, IMapper mapper, IBaseRepository<ReserveSeat> baseSeatsRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _baseSeatsRepository = baseSeatsRepository;
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
                _baseSeatsRepository.AddList(SeatsList);
                return  _mapper.Map<BookingRequest>(_baseRepository.Add(ticket));
            }
            catch
            {
                throw;
            }
        }
    }
}
