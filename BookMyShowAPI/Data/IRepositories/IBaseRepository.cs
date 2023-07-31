namespace Data.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void AddList(List<T> entity);
    }
}