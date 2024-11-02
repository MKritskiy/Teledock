using Teledock.Models;
using Teledock.Repositories.Interfaces;
using Teledock.Services.Interfaces;

namespace Teledock.Services.Classes
{
    public class ClientService : Service<Client>, IClientService
    {
        private readonly IFounderRepository _founderRepository;
        private readonly IClientRepository _clientRepository;

        public ClientService(
            IRepository<Client> repository, 
            ILogger<Service<Client>> logger, 
            IFounderRepository founderRepository, 
            IClientRepository clientRepository
            ) : base(repository, logger)
        {
            _founderRepository = founderRepository;
            _clientRepository = clientRepository;
        }

        public async Task AddFounderToClient(int clientId, Founder founder)
        {
            try
            {
                var client = await _clientRepository.GetById(clientId);
                if (client == null)
                    throw new Exception("The client with the same id was not found");
                client.Founders?.Add(founder);
                await _clientRepository.Update(client);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding founder to client");
                throw;
            }
        }

        public async Task RemoveFounderFromClient(int clientId, int founderId)
        {
            try
            {
                var client = await _clientRepository.GetById(clientId);
                if (client == null)
                    throw new Exception("The client with the same id was not found");
                var founder = client.Founders?.FirstOrDefault(f=>f.Id == founderId);
                if (founder == null)
                    throw new Exception("The founder with the same id was not found");
                client.Founders?.Remove(founder);
                await _clientRepository.Update(client);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing founder from client");
                throw;
            }
        }
    }
}
