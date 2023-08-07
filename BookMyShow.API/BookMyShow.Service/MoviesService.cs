using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.Data.IRepositories;
using BookMyShow.Services.Contracts;

namespace BookMyShow.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IBaseRepository<Movie> _baseRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly ITheatreRepository _theatreRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMapper mapper, IBaseRepository<Movie> repository, ITheatreRepository theatreRepository, IMoviesRepository moviesRepository)
        {
            _mapper = mapper;
            _theatreRepository = theatreRepository;
            _baseRepository = repository;
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<DomainModels.Movie> GetMovies(string location)
        {
            try
            {
                IEnumerable<DomainModels.Theatre> theatres = _theatreRepository.GetTheatres(location);
                if (theatres.Any())
                {
                    List<int> movieIds = theatres
                        .SelectMany(t => t.MovieIds)
                        .ToList();
                    IEnumerable<DomainModels.Movie> movies = _moviesRepository.GetMovies(movieIds);
                    return movies;
                }
                throw new Exception("No theatres found in the given location");
            }
            catch
            {
                throw ;
            }
        }
    }
}
