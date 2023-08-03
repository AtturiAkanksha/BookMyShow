using AutoMapper;
using DomainModels;
using Data.IRepositories;
using Service.Contracts;

namespace Service
{
    public class TheatreService : ITheatreService
    {
        private readonly IBaseRepository<Data.DataModels.Theatre> _baseRepository;
        private readonly IBaseRepository<Data.DataModels.ReservedSeat> _seatsRepository;
        private readonly IMapper _mapper;

        public TheatreService(IMapper mapper,IBaseRepository<Data.DataModels.Theatre> baseRepository, IBaseRepository<Data.DataModels.ReservedSeat> seatsRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _seatsRepository = seatsRepository;
        }

        public IEnumerable<Data.DataModels.ReservedSeat> Seats()
        {
            return _seatsRepository.GetAll();
        }

        public IEnumerable<Theatre> GetTheatres(int movieId)
        {
            List<Theatre> allTheatres = _mapper.Map<List<Theatre>>(_baseRepository.GetAll());
            IEnumerable<Theatre> theatres = allTheatres
              .Where(t => t.MovieIds.Contains(movieId))
              .ToList();
            return theatres;
        }

        public Theatre GetTheatresById(int id)
        {
            Theatre theatres = _mapper.Map<Theatre>(_baseRepository.GetById(id));
            return theatres;
        }
    }
}
