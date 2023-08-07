using AutoMapper;
using BookMyShow.DomainModels;
using BookMyShow.Data.IRepositories;
using BookMyShow.Services.Contracts;

namespace BookMyShow.Services
{
    public class TheatreService : ITheatreService
    {
        private readonly IBaseRepository<Data.DataModels.Theatre> _baseRepository;
        private readonly IBaseRepository<Data.DataModels.ReserveSeat> _seatsRepository;
        private readonly IMapper _mapper;

        public TheatreService(IMapper mapper, IBaseRepository<Data.DataModels.Theatre> baseRepository, IBaseRepository<Data.DataModels.ReserveSeat> seatsRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _seatsRepository = seatsRepository;
        }

        public IEnumerable<ReservedSeat> GetReservedSeats(ReservedSeat reservedSeatRequest)
        {
            List<ReservedSeat> allReservedSeats = _mapper.Map<List<ReservedSeat>>(_seatsRepository.GetAll());
            IEnumerable<ReservedSeat> reservedSeats = allReservedSeats.Where(seats => seats.TheatreId == reservedSeatRequest.TheatreId
            && seats.MovieTime == reservedSeatRequest.MovieTime).ToList();
            return reservedSeats;
        }

        public IEnumerable<Theatre> GetTheatres(int movieId)
        {
            try
            {
                List<Theatre> allTheatres = _mapper.Map<List<Theatre>>(_baseRepository.GetAll());
                IEnumerable<Theatre> theatres = allTheatres
                  .Where(t => t.MovieIds.Contains(movieId))
                  .ToList();
                if (theatres != null)
                {
                    return theatres;
                }
                throw new Exception("No theatres exist with given movieId");
            }
            catch
            {
                throw;
            }
        }

        public Theatre GetTheatreById(int id)
        {
            try
            {
                Theatre theatres = _mapper.Map<Theatre>(_baseRepository.GetById(id));
                if (theatres != null)
                {
                    return theatres;
                }
                throw new Exception("Theatre doesn't exist with the given id");
            }
            catch
            {
                throw;
            }
        }
    }
}
