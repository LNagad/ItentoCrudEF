using Core.Application.Interfaces.Services;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItentoCrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_regionService.GetAllAsyncEnumerable());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_regionService.GetAllAsyncEnumerable());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            return Ok(await _regionService.AddAsync(name));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] string name, int id)
        {
            return Ok(await _regionService.UpdateAsync(name, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _regionService.DeleteAsync(id));
        }
    }
}
