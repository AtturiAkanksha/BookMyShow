using DomainModels;
namespace Service.Contracts
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetMovies(string location);
        Movie GetById(int id);
    }
}
