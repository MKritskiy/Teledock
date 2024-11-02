using Microsoft.AspNetCore.Mvc;
using Teledock.Dto;
using Teledock.Dto.Mapper;
using Teledock.Models;
using Teledock.Services.Interfaces;

namespace Teledock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> Create(ClientDto clientDto)
        {
            Client client = ClientDtoMapper.MapClientDtoToClient(clientDto);
            client = await _clientService.Add(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        // Read
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAll();
            return Ok(clients);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClientDto clientDto)
        {
            Client client = await _clientService.GetById(id);
            ClientDtoMapper.MapClientDtoToClient(clientDto, client);
            client.Id = id;
            await _clientService.Update(client);
            return Ok(client);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.Delete(id);
            return NoContent();
        }
        // If FoundersController is not needed
        //// Add Founder to Client
        //[HttpPost("{clientId}/founders")]
        //public async Task<IActionResult> AddFounderToClient(int clientId, FounderDto founderDto)
        //{
        //    Founder founder = FounderDtoMapper.MapFounderDtoToFounder(founderDto);
        //    await _clientService.AddFounderToClient(clientId, founder);
        //    return Ok(founder);
        //}

        //// Remove Founder from Client
        //[HttpDelete("{clientId}/founders/{founderId}")]
        //public async Task<IActionResult> RemoveFounderFromClient(int clientId, int founderId)
        //{
        //    await _clientService.RemoveFounderFromClient(clientId, founderId);
        //    return NoContent();
        //}
    }
}
