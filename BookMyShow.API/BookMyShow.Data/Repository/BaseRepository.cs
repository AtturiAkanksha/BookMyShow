using BookMyShow.Data;
using BookMyShow.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BookMyShowDbContext _dbContext;
        DbSet<T> _entity;

        public BaseRepository(BookMyShowDbContext context)
        {
            _dbContext = context;
            _entity = _dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            try
            {
                _entity.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddList(List<T> entity)
        {
            try
            {
                _entity.AddRange(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }
    }
}
