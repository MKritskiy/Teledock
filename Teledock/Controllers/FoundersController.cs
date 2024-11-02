using Microsoft.AspNetCore.Mvc;
using Teledock.Dto;
using Teledock.Dto.Mapper;
using Teledock.Models;
using Teledock.Services.Interfaces;

namespace Teledock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoundersController : ControllerBase
    {
        private readonly IFounderService _founderService;

        public FoundersController(IFounderService founderService)
        {
            _founderService = founderService;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> Create(FounderDto founderDto)
        {
            
            Founder founder = FounderDtoMapper.MapFounderDtoToFounder(founderDto);
            founder = await _founderService.Add(founder);
            return CreatedAtAction(nameof(GetById), new { id = founder.Id }, founder);
        }

        // Read
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var founder = await _founderService.GetById(id);
            if (founder == null) return NotFound();
            return Ok(founder);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var founders = await _founderService.GetAll();
            return Ok(founders);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FounderDto founderDto)
        {
            Founder founder = await _founderService.GetById(id);
            FounderDtoMapper.MapFounderDtoToFounder(founderDto, founder);

            await _founderService.Update(founder);
            return Ok(founder);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _founderService.Delete(id);
            return NoContent();
        }
    }
}
