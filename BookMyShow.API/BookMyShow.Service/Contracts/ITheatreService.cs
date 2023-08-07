using BookMyShow.DomainModels;

namespace BookMyShow.Services.Contracts
{
    public interface ITheatreService
    {
        DomainModels.Theatre GetTheatreById(int id);
        IEnumerable<ReservedSeat> GetReservedSeats(ReservedSeat reservedSeatRequest);
        IEnumerable<DomainModels.Theatre> GetTheatres(int movieId);
    }
}
