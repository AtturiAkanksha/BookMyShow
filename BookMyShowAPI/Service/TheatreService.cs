using AutoMapper;
using Data.DataModels;
using Data.IRepositories;
using Service.Contracts;

namespace Service
{
    public class TheatreService : ITheatreService
    {
        private readonly IBaseRepository<Theatres> _baseRepository;
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public TheatreService(IMapper mapper, IMoviesService moviesService, IBaseRepository<Theatres> baseRepository)
        {
            _mapper = mapper;
            _moviesService = moviesService;
            _baseRepository = baseRepository;
        }
        public DomainModels.Theatres GetTheatres(int id)
        {
            DomainModels.Movies movie = _moviesService.GetById(id);
            DomainModels.Theatres theatres = _mapper.Map<DomainModels.Theatres>(_baseRepository.GetById(movie.TheatresId));
            return theatres;
        }
    }
}
