using BookMyShow.DomainModels;

namespace BookMyShow.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUser(string email);
    }
}
