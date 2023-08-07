using BookMyShow.DomainModels;
namespace BookMyShow.Services.Contracts
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetMovies(string location);
    }
}
