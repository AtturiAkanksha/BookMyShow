using Data.DataModels;
using Data.IRepositories;
using Service.Contracts;

namespace Service
{
    public class ReservedSeatsService : IReservedSeatsService
    {
        private readonly IBaseRepository<ReservedSeats> _seatsRepository;
        public ReservedSeatsService(IBaseRepository<ReservedSeats> seatsRepository)
        {
            _seatsRepository = seatsRepository;
        }

        public void Add(List<ReservedSeats> reservedSeats)
        {
            _seatsRepository.AddList(reservedSeats);
        }

        public IEnumerable<ReservedSeats> GetAll()
        {
            return _seatsRepository.GetAll();
        }
    }
}
