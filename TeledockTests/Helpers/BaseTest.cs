using Microsoft.Extensions.Logging;
using Moq;
using Teledock.Controllers;
using Teledock.Models;
using Teledock.Repositories.Interfaces;
using Teledock.Services.Classes;
using Teledock.Services.Interfaces;
using Xunit;

namespace TeledockTests.Helpers
{
    public class BaseTest
    {
        protected readonly Mock<IRepository<Client>> _clientRepositoryMock;
        protected readonly Mock<IFounderRepository> _founderRepositoryMock;
        protected readonly Mock<IClientRepository> _clientRepositoryMock2;
        protected readonly Mock<ILogger<Service<Client>>> _loggerMock;
        protected readonly ClientService _clientService;
        protected readonly Service<Client> _service;
        protected readonly Mock<IRepository<Client>> _repositoryMock;
        protected readonly Mock<IFounderService> _founderServiceMock;
        protected readonly Mock<IClientService> _clientServiceMock;
        protected readonly FoundersController _foundersController;
        protected readonly ClientsController _clientsController;
        public BaseTest()
        {
            _clientRepositoryMock = new Mock<IRepository<Client>>();
            _founderRepositoryMock = new Mock<IFounderRepository>();
            _clientRepositoryMock2 = new Mock<IClientRepository>();
            _loggerMock = new Mock<ILogger<Service<Client>>>();
            _repositoryMock = new Mock<IRepository<Client>>();
            _loggerMock = new Mock<ILogger<Service<Client>>>();
            _founderServiceMock = new Mock<IFounderService>();
            _clientServiceMock = new Mock<IClientService>();

            _service = new Service<Client>(_repositoryMock.Object, _loggerMock.Object);
            _clientService = new ClientService(
                _clientRepositoryMock.Object,
                _loggerMock.Object,
                _founderRepositoryMock.Object,
                _clientRepositoryMock2.Object
            );

            _foundersController = new FoundersController(_founderServiceMock.Object);
            _clientsController = new ClientsController(_clientServiceMock.Object);
        }
    }
}
