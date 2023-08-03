using AutoMapper;
using Data.DataModels;
using Data.IRepositories;
using Service.Contracts;

namespace Service
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
            IEnumerable<DomainModels.Theatre> theatres = _theatreRepository.GetTheatres(location);
            List<int> movieIds = theatres
                .SelectMany(t => t.MovieIds)
                .ToList();
            IEnumerable<DomainModels.Movie> movies = _moviesRepository.GetMovies(movieIds);
            return movies;
        }

        public DomainModels.Movie GetById(int id)
        {
            DomainModels.Movie movie = _mapper.Map<DomainModels.Movie>(_baseRepository.GetById(id));
            return movie;
        }
    }
}
