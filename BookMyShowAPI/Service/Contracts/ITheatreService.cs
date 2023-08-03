namespace Service.Contracts
{
    public interface ITheatreService
    {
        DomainModels.Theatre GetTheatresById(int id);
        IEnumerable<Data.DataModels.ReservedSeat> Seats();
        IEnumerable<DomainModels.Theatre> GetTheatres(int movieId);
    }
}
