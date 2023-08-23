using BookMyShow.DomainModels;
using BookMyShow.Data.IRepositories;
using BookMyShow.Services.Contracts;

namespace BookMyShow.Services
{
    public class TheatreService : ITheatreService
    {
        private readonly ITheatreRepository _theatreRepository;

        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }

        public IEnumerable<ReservedSeat> GetReservedSeats(ReservedSeat reservedSeatRequest)
        {
            return _theatreRepository.GetReservedSeats(reservedSeatRequest);
        }

        public IEnumerable<Theatre> GetTheatresByMovieId(int movieId)
        {
            return _theatreRepository.GetTheatresByMovieId(movieId);
        }

        public IEnumerable<Theatre> GetTheatresByLocation(string location)
        {
            return _theatreRepository.GetTheatresByLocation(location);
        }

        public Theatre GetTheatreById(int id)
        {
            return _theatreRepository.GetTheatreById(id);
        }
    }
}
