namespace Service.Contracts
{
    public interface ITheatreService
    {
        DomainModels.Theatres GetTheatres(int id);
    }
}
