using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.Data.IRepositories;

namespace BookMyShow.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookMyShowDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository (BookMyShowDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DomainModels.User> GetUser(string email)
        {
            User user = _dbContext.Users.FirstOrDefault(user => user.Email == email);
            return _mapper.Map<DomainModels.User>(user);
        }
    }
}
