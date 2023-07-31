using DomainModels;
namespace Service.Contracts
{
    public interface IMoviesService
    {
        IEnumerable<Movies> GetMovies(string location);
        Movies GetById(int id);
    }
}
