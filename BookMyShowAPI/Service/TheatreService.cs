using AutoMapper;
using Data.DataModels;
using Data.IRepositories;
using Service.Contracts;

namespace Service
{
    public class TheatreService : ITheatreService
    {
        private readonly IBaseRepository<Theatre> _baseRepository;
        private readonly IMoviesService _moviesService;
        private readonly IBaseRepository<Data.DataModels.ReservedSeat> _seatsRepository;
        private readonly IMapper _mapper;

        public TheatreService(IMapper mapper, IMoviesService moviesService, IBaseRepository<Theatre> baseRepository, IBaseRepository<Data.DataModels.ReservedSeat> seatsRepository)
        {
            _mapper = mapper;
            _moviesService = moviesService;
            _baseRepository = baseRepository;
            _seatsRepository = seatsRepository;
        }

        public IEnumerable<Data.DataModels.ReservedSeat> Seats()
        {
            return _seatsRepository.GetAll();
        }

        public DomainModels.Theatre GetTheatres(int id)
        {
            DomainModels.Movie movie = _moviesService.GetById(id);
            DomainModels.Theatre theatres = _mapper.Map<DomainModels.Theatre>(_baseRepository.GetById(movie.TheatresId));
            return theatres;
        }
    }
}
