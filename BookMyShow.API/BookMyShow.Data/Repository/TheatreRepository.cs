using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.Data.IRepositories;
using BookMyShow.DomainModels;

namespace BookMyShow.Data.Repository
{
    public class TheatreRepository : ITheatreRepository
    {
        private readonly IMapper _mapper;
        private readonly BookMyShowDbContext _dbContext;
        private readonly IBaseRepository<DataModels.Theatre> _baseRepository;

        public TheatreRepository(IMapper mapper, BookMyShowDbContext dbContext, IBaseRepository<DataModels.Theatre> baseRepository)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _baseRepository = baseRepository;
        }

        public IEnumerable<DomainModels.Theatre> GetTheatresByLocation(string locationName)
        {
            try
            {
                IEnumerable<DataModels.Theatre> theatresInLocation = _dbContext.Theatres.Where(t => t.Location == locationName);
                return _mapper.Map<IEnumerable<DomainModels.Theatre>>(theatresInLocation);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ReservedSeat> GetReservedSeats(ReservedSeat reservedSeatRequest)
        {
            IEnumerable<ReserveSeat> reservedSeats = _dbContext.ReservedSeats.Where(seats => seats.TheatreId == reservedSeatRequest.TheatreId
            && seats.ShowTime == reservedSeatRequest.ShowTime);
            return _mapper.Map<IEnumerable<ReservedSeat>>(reservedSeats);
        }

        public DomainModels.Theatre GetTheatreById(int id)
        {
            try
            {
                DomainModels.Theatre theatres = _mapper.Map<DomainModels.Theatre>(_baseRepository.GetById(id));
                if (theatres != null)
                {
                    return _mapper.Map<DomainModels.Theatre>(theatres);
                }
                throw new Exception("Theatre doesn't exist with the given id");
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<DomainModels.Theatre> GetTheatresByMovieId(int movieId)
        {
            try
            {
                IEnumerable<DataModels.Theatre> theatres = _dbContext.Theatres
                  .Where(t => t.MovieIds.Contains(movieId.ToString()))
                  .ToList();
                if (theatres != null)
                {
                    return _mapper.Map<IEnumerable<DomainModels.Theatre>>(theatres);
                }
                throw new Exception("No theatres exist with given movieId");
            }
            catch
            {
                throw;
            }
        }
    }
}
