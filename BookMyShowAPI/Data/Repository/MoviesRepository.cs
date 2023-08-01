using AutoMapper;
using DomainModels;
using Data.IRepositories;

namespace Data.Repository
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

        public IEnumerable<Movie> GetMovies(string location)
        {
            IEnumerable<Movie> allMovies = _mapper.Map<IEnumerable<Movie>>(_moviesRepository.GetAll());
            IEnumerable<Movie> movies = allMovies.Where(movie => movie.LocationNames == location).ToList();
            return movies;
        }
    }
}
