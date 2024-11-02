using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teledock.Models.Enums;
using Teledock.Models;
using TeledockTests.Helpers;

namespace TeledockTests
{
    public class ServiceTests : BaseTest
    {
        [Fact]
        public async Task Add_ShouldAddEntity()
        {
            
            var client = new Client { Id = 1, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _repositoryMock.Setup(repo => repo.Add(client)).Returns(Task.CompletedTask);

            
            await _service.Add(client);

            
            _repositoryMock.Verify(repo => repo.Add(client), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldThrowExceptionIfErrorOccurs()
        {
            
            var client = new Client { Id = 1, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _repositoryMock.Setup(repo => repo.Add(client)).ThrowsAsync(new Exception("Test exception"));

            
            await Assert.ThrowsAsync<Exception>(() => _service.Add(client));

        }

        [Fact]
        public async Task Delete_ShouldDeleteEntity()
        {
            
            var clientId = 1;
            var client = new Client { Id = clientId, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _repositoryMock.Setup(repo => repo.GetById(clientId)).ReturnsAsync(client);
            _repositoryMock.Setup(repo => repo.Delete(client)).Returns(Task.CompletedTask);

           
            await _service.Delete(clientId);

            
            _repositoryMock.Verify(repo => repo.GetById(clientId), Times.Once);
            _repositoryMock.Verify(repo => repo.Delete(client), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldThrowExceptionIfEntityNotFound()
        {
            
            var clientId = 1;
            _repositoryMock.Setup(repo => repo.GetById(clientId)).ReturnsAsync((Client)null);

            
            await Assert.ThrowsAsync<Exception>(() => _service.Delete(clientId));
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllEntities()
        {
            
            var clients = new List<Client>
            {
            new Client { Id = 1, INN = "1234567890", Name = "Client Name 1", ClientType = ClientType.IndividualEntrepreneurs },
            new Client { Id = 2, INN = "1234567891", Name = "Client Name 2", ClientType = ClientType.LegalEntities }
            };
            _repositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(clients);

            
            var result = await _service.GetAll();

            
            _repositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            Assert.Equal(clients, result);
        }

        [Fact]
        public async Task GetAll_ShouldThrowExceptionIfErrorOccurs()
        {
            
            _repositoryMock.Setup(repo => repo.GetAll()).ThrowsAsync(new Exception("Test exception"));

            
            await Assert.ThrowsAsync<Exception>(() => _service.GetAll());
        }

        [Fact]
        public async Task GetById_ShouldReturnEntity()
        {
            
            var clientId = 1;
            var client = new Client { Id = clientId, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _repositoryMock.Setup(repo => repo.GetById(clientId)).ReturnsAsync(client);

            
            var result = await _service.GetById(clientId);

            
            _repositoryMock.Verify(repo => repo.GetById(clientId), Times.Once);
            Assert.Equal(client, result);
        }

        [Fact]
        public async Task GetById_ShouldThrowExceptionIfEntityNotFound()
        {

            var clientId = 1;
            _repositoryMock.Setup(repo => repo.GetById(clientId)).ReturnsAsync((Client)null);


            await Assert.ThrowsAsync<Exception>(() => _service.GetById(clientId));
 
        }

        [Fact]
        public async Task Update_ShouldUpdateEntity()
        {

            var client = new Client { Id = 1, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _repositoryMock.Setup(repo => repo.Update(client)).Returns(Task.CompletedTask);


            await _service.Update(client);


            _repositoryMock.Verify(repo => repo.Update(client), Times.Once);
        }
        [Fact]
        public async Task Update_ShouldThrowExceptionIfErrorOccurs()
        {

            var client = new Client { Id = 1, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _repositoryMock.Setup(repo => repo.Update(client)).ThrowsAsync(new Exception("Test exception"));


            await Assert.ThrowsAsync<Exception>(() => _service.Update(client));
        }
    }
}
