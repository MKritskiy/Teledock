using System.Diagnostics.Metrics;
using Teledock.DAL.Classes;
using Teledock.Models;
using Teledock.Repositories.Interfaces;
using Teledock.Services.Interfaces;

namespace Teledock.Services.Classes
{
    public class FounderService : Service<Founder>, IFounderService
    {
        public FounderService(IRepository<Founder> repository, ILogger<Service<Founder>> logger) 
            : base(repository, logger)
        {
        }

        
    }
}
