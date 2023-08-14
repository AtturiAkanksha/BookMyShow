using BookMyShow.DomainModels;

namespace BookMyShow.Data.IRepositories
{
    public interface ITheatreRepository
    {
        IEnumerable<Theatre> GetTheatresByLocation(string locationName);
        IEnumerable<Theatre> GetTheatresByMovieId(int movieId);
        Theatre GetTheatreById(int id);
        IEnumerable<ReservedSeat> GetReservedSeats(ReservedSeat reservedSeatRequest);
    }
}
