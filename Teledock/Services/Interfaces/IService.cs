namespace Teledock.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Delete(int id);
    }
}
