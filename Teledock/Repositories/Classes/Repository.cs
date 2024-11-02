using Microsoft.EntityFrameworkCore;
using Teledock.Database;
using Teledock.Repositories.Interfaces;

namespace Teledock.DAL.Classes
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ClientContext _context;
        protected Repository(ClientContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
