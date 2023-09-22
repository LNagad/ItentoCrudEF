using Core.Application.DTO;
using Core.Application.Interfaces.Services;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItentoCrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonTypeController : ControllerBase
    {
        private readonly IPokemonTypeService _pokemonTypeService;

        public PokemonTypeController(IPokemonTypeService pokemonTypeService)
        {
            _pokemonTypeService = pokemonTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pokemonTypeService.GetAllAsyncEnumerable());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pokemonTypeService.GetAllAsyncEnumerable());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            return Ok(await _pokemonTypeService.AddAsync(name));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] string name, int id)
        {
            return Ok(await _pokemonTypeService.UpdateAsync(name, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _pokemonTypeService.DeleteAsync(id));
        }
    }
}
