using DomainModels;

namespace Data.IRepositories
{
    public interface ITheatreRepository
    {
        IEnumerable<Theatre> GetTheatres(string locationName);
    }
}
