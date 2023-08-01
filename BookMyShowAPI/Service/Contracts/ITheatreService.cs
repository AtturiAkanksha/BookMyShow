namespace Service.Contracts
{
    public interface ITheatreService
    {
        DomainModels.Theatre GetTheatres(int id);
        IEnumerable<Data.DataModels.ReservedSeat> Seats();
    }
}
