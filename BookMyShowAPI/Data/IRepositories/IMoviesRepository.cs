namespace Data.IRepositories
{
    public interface IMoviesRepository
    {
        IEnumerable<DomainModels.Movies> GetMovies(string location);
    }
}
