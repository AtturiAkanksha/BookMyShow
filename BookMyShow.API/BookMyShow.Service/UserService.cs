using BookMyShow.Data.IRepositories;
using BookMyShow.DomainModels;
using BookMyShow.Services.Contracts;

namespace BookMyShow.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(string email)
        {
            return await  _userRepository.GetUser(email);
        }
    }
}
