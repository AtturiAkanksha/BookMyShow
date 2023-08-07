namespace BookMyShow.Data.IRepositories
{
    public interface IMoviesRepository
    {
        IEnumerable<DomainModels.Movie> GetMovies(List<int> movieIds);
    }
}
