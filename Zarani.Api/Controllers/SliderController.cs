using Microsoft.AspNetCore.Mvc;
using Zarani.Application.Services.Slider;
using Zarani.Domain.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Zarani.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : BaseController<SliderController>
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sliderService.GetAllSliders();
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost("AddSlider")]
        public async Task<IActionResult> AddSlider([FromBody] SliderDto sliderDto)
        {
            if (sliderDto == null)
            {
                return BadRequest("Invalid slider data");
            }

            var result = await _sliderService.AddSlider(sliderDto);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("GetSliderById/{id}")]
        public async Task<IActionResult> GetSliderById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid parameter");
            }

            var result = await _sliderService.GetSliderById(id);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return NotFound(result.ErrorMessage);
        }

        [HttpPut("UpdateSlider")]
        public async Task<IActionResult> UpdateSlider([FromBody] SliderDto sliderDto)
        {
            if (sliderDto == null)
            {
                return BadRequest("Invalid slider data");
            }

            var result = await _sliderService.UpdateSlider(sliderDto);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("DeleteSlider/{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid parameter");
            }

            var result = await _sliderService.DeleteSlider(id);
            if (result.Data)
            {
                return Ok(result.Data);
            }
            return NotFound(result.ErrorMessage);
        }
    }
}
