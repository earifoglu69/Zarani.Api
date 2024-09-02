using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zarani.Application.Services.Module;
using Zarani.Domain.Dtos;

namespace Zarani.Api.Controllers
{
    public class ModuleController : BaseController<ModuleController>
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpPost]
        [Authorize]
        [Route("GetAllModules")]
        public async Task<IActionResult> GetAllModules()
        {
            return Ok(await _moduleService.GetAllModules());
        }

        [HttpPost]
        [Route("AddModule")]
        public async Task<IActionResult> AddModule([FromBody] ModuleDto moduleDto)
        {
            var result = await _moduleService.AddModule(moduleDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("GetModuleById/{id}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            var result = await _moduleService.GetModuleById(id);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return NotFound(result.ErrorMessage);
        }

        [HttpPut]
        [Route("UpdateModule")]
        public async Task<IActionResult> UpdateModule([FromBody] ModuleDto moduleDto)
        {
            var result = await _moduleService.UpdateModule(moduleDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete]
        [Route("DeleteModule/{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var result = await _moduleService.DeleteModule(id);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result.ErrorMessage);
        }
    }
}

