using Data.DataModels;
namespace Service.Contracts
{
    public interface IReservedSeatsService
    {
        void Add(List<ReservedSeats> reservedSeats);
        IEnumerable<ReservedSeats> GetAll();
    }
}
