using BookMyShow.DomainModels;

namespace BookMyShow.Data.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(string email);
    }
}
