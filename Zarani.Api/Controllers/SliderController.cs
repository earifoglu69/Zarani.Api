using Microsoft.AspNetCore.Mvc;
using Zarani.Application.Services.Slider;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;

namespace Zarani.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        // GET: api/Slider
        [HttpGet]
        public async Task<IActionResult> GetAllSliders()
        {
            var response = await _sliderService.GetAllSliders();
            return Ok(response);
        }

        // GET: api/Slider/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSliderById(int id)
        {
            var response = await _sliderService.GetSliderById(id);
            if (response.Data == null)
            {
                return NotFound(response.ErrorMessage);
            }
            return Ok(response);
        }

        // POST: api/Slider
        [HttpPost]
        public async Task<IActionResult> AddSlider([FromBody] SliderDto sliderDto)
        {
            var response = await _sliderService.AddSlider(sliderDto);
            if (response.Data == null)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }

        // PUT: api/Slider
        [HttpPut]
        public async Task<IActionResult> UpdateSlider([FromBody] SliderDto sliderDto)
        {
            var response = await _sliderService.UpdateSlider(sliderDto);
            if (response.Data == null)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }

        // DELETE: api/Slider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var response = await _sliderService.DeleteSlider(id);
            if (!response.Data)
            {
                return NotFound(response.ErrorMessage);
            }
            return Ok(response);
        }
    }
}
