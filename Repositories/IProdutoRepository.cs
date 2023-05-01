namespace Web.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Add(T obj);
        Task Remove(int id);
        Task Update(T obj);
        Task<T> GetOne(int id);
        IEnumerable<T> GetAll();
    }
}