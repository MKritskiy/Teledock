using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teledock.Dto;
using Teledock.Models.Enums;
using Teledock.Models;
using TeledockTests.Helpers;

namespace TeledockTests
{
    public class ClientsControllerTests : BaseTest
    {
        [Fact]
        public async Task Create_ShouldReturnCreatedAtActionResult()
        {

            var clientDto = new ClientDto { INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            var client = new Client { Id = 1, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _clientServiceMock.Setup(service => service.Add(It.IsAny<Client>())).ReturnsAsync(client);


            var result = await _clientsController.Create(clientDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);

            Assert.Equal(client, createdAtActionResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkObjectResult()
        {

            var clientId = 1;
            var client = new Client { Id = clientId, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _clientServiceMock.Setup(service => service.GetById(clientId)).ReturnsAsync(client);


            var result = await _clientsController.GetById(clientId);


            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(client, okObjectResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFoundResult()
        {

            var clientId = 1;
            _clientServiceMock.Setup(service => service.GetById(clientId)).ReturnsAsync((Client)null);


            var result = await _clientsController.GetById(clientId);


            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkObjectResult()
        {

            var clients = new List<Client>
            {
                new Client { Id = 1, INN = "1234567890", Name = "Client Name 1", ClientType = ClientType.IndividualEntrepreneurs },
                new Client { Id = 2, INN = "1234567891", Name = "Client Name 2", ClientType = ClientType.LegalEntities }
            };
            _clientServiceMock.Setup(service => service.GetAll()).ReturnsAsync(clients);

            var result = await _clientsController.GetAll();


            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(clients, okObjectResult.Value);
        }

        [Fact]
        public async Task Update_ShouldReturnOkObjectResult()
        {

            var clientId = 1;
            var clientDto = new ClientDto { INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            var client = new Client { Id = clientId, INN = "1234567890", Name = "Client Name", ClientType = ClientType.IndividualEntrepreneurs };
            _clientServiceMock.Setup(service => service.GetById(clientId)).ReturnsAsync(client);
            _clientServiceMock.Setup(service => service.Update(It.IsAny<Client>())).Returns(Task.CompletedTask);


            var result = await _clientsController.Update(clientId, clientDto);


            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(client, okObjectResult.Value);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContentResult()
        {

            var clientId = 1;
            _clientServiceMock.Setup(service => service.Delete(clientId)).Returns(Task.CompletedTask);

            var result = await _clientsController.Delete(clientId);


            Assert.IsType<NoContentResult>(result);
        }
    }
}
