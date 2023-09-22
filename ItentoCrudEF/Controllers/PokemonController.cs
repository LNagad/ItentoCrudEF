using Core.Application.DTO;
using Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItentoCrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pokemonService.GetAllAsyncEnumerable());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _pokemonService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PokemonDTO pokemon)
        {
            return Ok(await _pokemonService.AddAsync(pokemon));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PokemonDTO pokemon, int id)
        {
            return Ok(await _pokemonService.UpdateAsync(pokemon, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _pokemonService.DeleteAsync(id));
        }
    }
}
