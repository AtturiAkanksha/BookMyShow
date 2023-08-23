namespace BookMyShow.Data.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        T GetById(int id);
        void AddList(List<T> entity);
    }
}