using Moq;
using Teledock.Models.Enums;
using Teledock.Models;
using TeledockTests.Helpers;

namespace TeledockTests
{
    public class ClientServiceTests : BaseTest
    {
        [Fact]
        public async Task AddFounderToClient_ShouldAddFounderToClient()
        {  
            var clientId = 1;
            var founder = new Founder { Id = 1, INN = "1234567890", FullName = "John Doe", ClientId = clientId };
            var client = new Client { Id = clientId, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs, Founders = new List<Founder>() };

            _clientRepositoryMock2.Setup(repo => repo.GetById(clientId)).ReturnsAsync(client);
            _clientRepositoryMock2.Setup(repo => repo.Update(client)).Returns(Task.CompletedTask);

            
            await _clientService.AddFounderToClient(clientId, founder);

            
            _clientRepositoryMock2.Verify(repo => repo.GetById(clientId), Times.Once);
            _clientRepositoryMock2.Verify(repo => repo.Update(client), Times.Once);
        }

        [Fact]
        public async Task AddFounderToClient_ShouldThrowExceptionIfClientNotFound()
        {

            var clientId = 1;
            var founder = new Founder { Id = 1, INN = "1234567890", FullName = "John Doe", ClientId = clientId };

            _clientRepositoryMock2.Setup(repo => repo.GetById(clientId)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<Exception>(() => _clientService.AddFounderToClient(clientId, founder));
        }

        [Fact]
        public async Task RemoveFounderFromClient_ShouldRemoveFounderFromClient()
        {

            var clientId = 1;
            var founderId = 1;
            var founder = new Founder { Id = founderId, INN = "1234567890", FullName = "John Doe", ClientId = clientId };
            var client = new Client { Id = clientId, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs, Founders = new List<Founder> { founder } };

            _clientRepositoryMock2.Setup(repo => repo.GetById(clientId)).ReturnsAsync(client);
            _clientRepositoryMock2.Setup(repo => repo.Update(client)).Returns(Task.CompletedTask);

            await _clientService.RemoveFounderFromClient(clientId, founderId);


            _clientRepositoryMock2.Verify(repo => repo.GetById(clientId), Times.Once);
            _clientRepositoryMock2.Verify(repo => repo.Update(client), Times.Once);
            Assert.DoesNotContain(founder, client.Founders);
        }

        [Fact]
        public async Task RemoveFounderFromClient_ShouldThrowExceptionIfClientNotFound()
        {

            var clientId = 1;
            var founderId = 1;

            _clientRepositoryMock2.Setup(repo => repo.GetById(clientId)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<Exception>(() => _clientService.RemoveFounderFromClient(clientId, founderId));
        }

        [Fact]
        public async Task RemoveFounderFromClient_ShouldThrowExceptionIfFounderNotFound()
        {

            var clientId = 1;
            var founderId = 1;
            var client = new Client { Id = clientId, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs, Founders = new List<Founder>() };

            _clientRepositoryMock2.Setup(repo => repo.GetById(clientId)).ReturnsAsync(client);


            await Assert.ThrowsAsync<Exception>(() => _clientService.RemoveFounderFromClient(clientId, founderId));
        }
    }
}