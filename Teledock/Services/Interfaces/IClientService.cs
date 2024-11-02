using Teledock.Models;

namespace Teledock.Services.Interfaces
{
    public interface IClientService : IService<Client>
    {
        Task AddFounderToClient(int clientId, Founder founder);
        Task RemoveFounderFromClient(int clientId, int founderId);
    }
}
