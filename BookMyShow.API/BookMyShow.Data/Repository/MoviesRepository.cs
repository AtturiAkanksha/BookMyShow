using AutoMapper;
using BookMyShow.DomainModels;
using BookMyShow.Data.IRepositories;

namespace BookMyShow.Data.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<DataModels.Movie> _moviesRepository;

        public MoviesRepository(IMapper mapper, IBaseRepository<DataModels.Movie> moviesRepository)
        {
            _mapper = mapper;
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<Movie> GetMovies(List<int> movieIds)
        {
            try
            {
                IEnumerable<Movie> allMovies = _mapper.Map<IEnumerable<Movie>>(_moviesRepository.GetAll());
                IEnumerable<Movie> _movies = allMovies.Where(m => movieIds.Contains(m.Id)).ToList();
                return _movies;
            }
            catch
            {
                throw;
            }
        }
    }
}
