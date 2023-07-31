using AutoMapper;
using DomainModels;
using Data.IRepositories;

namespace Data.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<DataModels.Movies> _moviesRepository;
      
        public MoviesRepository(IMapper mapper, IBaseRepository<DataModels.Movies> moviesRepository)
        {
            _mapper = mapper;
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<Movies> GetMovies(string location)
        {
            IEnumerable<Movies> allMovies = _mapper.Map<IEnumerable<Movies>>(_moviesRepository.GetAll());
            IEnumerable<Movies> movies = allMovies.Where(movie => movie.LocationNames == location).ToList();
            return movies;
        }
    }
}
