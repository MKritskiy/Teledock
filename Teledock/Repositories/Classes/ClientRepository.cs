using Microsoft.EntityFrameworkCore;
using Teledock.Database;
using Teledock.Models;
using Teledock.Repositories.Interfaces;

namespace Teledock.DAL.Classes
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ClientContext context) : base(context)
        {
        }

        public override async Task<Client?> GetById(int id)
        {
            return await _context.Clients
                .Include(c=>c.Founders)
                .FirstOrDefaultAsync(c=>c.Id == id);
        }
        
        public override async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients
                .Include(c=>c.Founders)
                .ToListAsync();
        } 
    }
}
