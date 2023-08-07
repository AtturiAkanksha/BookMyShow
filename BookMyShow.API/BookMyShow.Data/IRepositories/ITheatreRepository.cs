using BookMyShow.DomainModels;

namespace BookMyShow.Data.IRepositories
{
    public interface ITheatreRepository
    {
        IEnumerable<Theatre> GetTheatres(string locationName);
    }
}
