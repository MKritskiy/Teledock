using Microsoft.EntityFrameworkCore;
using Teledock.Database;
using Teledock.Models;
using Teledock.Repositories.Interfaces;

namespace Teledock.DAL.Classes
{
    public class FounderRepository : Repository<Founder>, IFounderRepository
    {
        public FounderRepository(ClientContext context) : base(context)
        {
        }
    }
}
