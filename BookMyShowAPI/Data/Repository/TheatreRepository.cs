using AutoMapper;
using DomainModels;
using Data.IRepositories;

namespace Data.Repository
{
    public class TheatreRepository : ITheatreRepository
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<DataModels.Theatre> _theatreRepository;

        public TheatreRepository(IMapper mapper, IBaseRepository<DataModels.Theatre> theatreRepository)
        {
            _mapper = mapper;
            _theatreRepository = theatreRepository;
        }

        public IEnumerable<Theatre> GetTheatres(string locationName)
        {
            List<Theatre> theatres = _mapper.Map<List<Theatre>>(_theatreRepository.GetAll());
            IEnumerable<Theatre> theatresInLocation = theatres.Where(t => t.LocationName == locationName).ToList();
            return theatresInLocation;
        }
    }
}
