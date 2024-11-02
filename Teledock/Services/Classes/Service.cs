using Teledock.Repositories.Interfaces;
using Teledock.Services.Interfaces;

namespace Teledock.Services.Classes
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly ILogger<Service<T>> _logger;

        public Service(IRepository<T> repository, ILogger<Service<T>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public virtual async Task<T> Add(T entity)
        {
            try
            {
                await _repository.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating {typeof(T).Name}");
                throw;
            }
        }

        public virtual async Task Delete(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null)
                    throw new Exception("The element to delete was not found");
                await _repository.Delete(entity);                    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting {typeof(T).Name}");
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting all {typeof(T).Name}");
                throw;
            }
        }

        public virtual async Task<T> GetById(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity ==null)
                    throw new Exception("The element to get was not found");
                return entity;
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {typeof(T).Name} by id");
                throw;
            }
        }

        public virtual async Task Update(T entity)
        {
            try
            {
                await _repository.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {typeof(T).Name}");
                throw;
            }
        }
    }
}
