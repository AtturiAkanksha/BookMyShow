namespace Data.IRepositories
{
    public interface IMoviesRepository
    {
        IEnumerable<DomainModels.Movie> GetMovies(string location);
    }
}
