using AutoMapper;
using Data.IRepositories;
using Service.Contracts;

namespace Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IBaseRepository<Data.DataModels.Movie> _baseRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMapper mapper, IBaseRepository<Data.DataModels.Movie> repository, IMoviesRepository moviesRepository)
        {
            _mapper = mapper;
            _baseRepository = repository;
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<DomainModels.Movie> GetMovies(string location)
        {
            IEnumerable<DomainModels.Movie> movies = _moviesRepository.GetMovies(location);
            return movies;
        }

        public DomainModels.Movie GetById(int id)
        {
            DomainModels.Movie movie = _mapper.Map<DomainModels.Movie>(_baseRepository.GetById(id));
            return movie;
        }
    }
}
