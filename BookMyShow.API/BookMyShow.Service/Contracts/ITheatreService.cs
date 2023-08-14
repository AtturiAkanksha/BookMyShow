using BookMyShow.DomainModels;

namespace BookMyShow.Services.Contracts
{
    public interface ITheatreService
    {
        Theatre GetTheatreById(int id);
        IEnumerable<ReservedSeat> GetReservedSeats(ReservedSeat reservedSeatRequest);
        IEnumerable<Theatre> GetTheatresByMovieId(int movieId);
        IEnumerable<Theatre> GetTheatresByLocation(string location);
    }
}
