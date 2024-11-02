
namespace Teledock.Repositories.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
    }
}
