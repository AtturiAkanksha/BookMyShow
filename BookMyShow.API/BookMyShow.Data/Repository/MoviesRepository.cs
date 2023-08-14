using AutoMapper;
using BookMyShow.DomainModels;
using BookMyShow.Data.IRepositories;

namespace BookMyShow.Data.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMapper _mapper;
        private readonly BookMyShowDbContext _dbContext;

        public MoviesRepository(IMapper mapper, BookMyShowDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetMovies(List<int> movieIds)
        {
            try
            {
                IEnumerable<DataModels.Movie> _movies = _dbContext.Movies.Where(m => movieIds.Contains(m.Id));
                return _mapper.Map<IEnumerable<Movie>>(_movies);
            }
            catch
            {
                throw;
            }
        }
    }
}
