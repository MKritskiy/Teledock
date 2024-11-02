using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teledock.Dto;
using Teledock.Models;
using TeledockTests.Helpers;

namespace TeledockTests
{
    public class FoundersControllerTests : BaseTest
    {
        [Fact]
        public async Task Create_ShouldReturnCreatedAtActionResult()
        {
            
            var founderDto = new FounderDto { INN = "1234567890", FullName = "John Doe", ClientId = 1 };
            var founder = new Founder { Id = 1, INN = "1234567890", FullName = "John Doe", ClientId = 1 };
            _founderServiceMock.Setup(service => service.Add(It.IsAny<Founder>())).ReturnsAsync(founder);


            var result = await _foundersController.Create(founderDto);


            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(founder, createdAtActionResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkObjectResult()
        {

            var founderId = 1;
            var founder = new Founder { Id = founderId, INN = "1234567890", FullName = "John Doe", ClientId = 1 };
            _founderServiceMock.Setup(service => service.GetById(founderId)).ReturnsAsync(founder);


            var result = await _foundersController.GetById(founderId);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(founder, okObjectResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFoundResult()
        {

            var founderId = 1;
            _founderServiceMock.Setup(service => service.GetById(founderId)).ReturnsAsync((Founder)null);


            var result = await _foundersController.GetById(founderId);


            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkObjectResult()
        {

            var founders = new List<Founder>
            {
                new Founder { Id = 1, INN = "1234567890", FullName = "John Doe", ClientId = 1 },
                new Founder { Id = 2, INN = "1234567891", FullName = "Jane Doe", ClientId = 2 }
            };
            _founderServiceMock.Setup(service => service.GetAll()).ReturnsAsync(founders);


            var result = await _foundersController.GetAll();

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(founders, okObjectResult.Value);
        }

        [Fact]
        public async Task Update_ShouldReturnOkObjectResult()
        {

            var founderId = 1;
            var founderDto = new FounderDto { INN = "1234567890", FullName = "John Doe", ClientId = 1 };
            var founder = new Founder { Id = founderId, INN = "1234567890", FullName = "John Doe", ClientId = 1 };
            _founderServiceMock.Setup(service => service.GetById(founderId)).ReturnsAsync(founder);
            _founderServiceMock.Setup(service => service.Update(It.IsAny<Founder>())).Returns(Task.CompletedTask);

            var result = await _foundersController.Update(founderId, founderDto);


            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(founder, okObjectResult.Value);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContentResult()
        {

            var founderId = 1;
            _founderServiceMock.Setup(service => service.Delete(founderId)).Returns(Task.CompletedTask);


            var result = await _foundersController.Delete(founderId);


            Assert.IsType<NoContentResult>(result);
        }
    }
}
