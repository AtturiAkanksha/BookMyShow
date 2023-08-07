using AutoMapper;
using BookMyShow.DomainModels;
using BookMyShow.Data.IRepositories;

namespace BookMyShow.Data.Repository
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
            try
            {
                List<Theatre> theatres = _mapper.Map<List<Theatre>>(_theatreRepository.GetAll());
                IEnumerable<Theatre> theatresInLocation = theatres.Where(t => t.LocationName == locationName).ToList();
                return theatresInLocation;
            }
            catch
            {
                throw;
            }
        }
    }
}
