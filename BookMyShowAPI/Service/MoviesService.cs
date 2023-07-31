using AutoMapper;
using Data.IRepositories;
using Service.Contracts;

namespace Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IBaseRepository<Data.DataModels.Movies> _baseRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMapper mapper, IBaseRepository<Data.DataModels.Movies> repository, IMoviesRepository moviesRepository)
        {
            _mapper = mapper;
            _baseRepository = repository;
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<DomainModels.Movies> GetMovies(string location)
        {
            IEnumerable<DomainModels.Movies> movies = _moviesRepository.GetMovies(location);
            return movies;
        }

        public DomainModels.Movies GetById(int id)
        {
            DomainModels.Movies movie = _mapper.Map<DomainModels.Movies>(_baseRepository.GetById(id));
            return movie;
        }
    }
}
