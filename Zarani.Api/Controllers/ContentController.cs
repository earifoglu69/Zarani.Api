using Microsoft.AspNetCore.Mvc;
using Zarani.Application.Services;
using Zarani.Domain.Dtos;
using Zarani.Domain.Request;

namespace Zarani.Api.Controllers
{
    public class ContentController : BaseController<ContentController>
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost]
        [Route("GetAllContents")]
        public async Task<IActionResult> GetAllContents()
        {
            return Ok(await _contentService.GetAllContents());
        }

        [HttpPost]
        [Route("AddContent")]
        public async Task<IActionResult> AddContent([FromBody] ContentDto contentDto)
        {
            var result = await _contentService.AddContent(contentDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("GetContentById/{id}")]
        public async Task<IActionResult> GetContentById(int id)
        {
            var result = await _contentService.GetContentById(id);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return NotFound(result.ErrorMessage);
        }

        [HttpPut]
        [Route("UpdateContent")]
        public async Task<IActionResult> UpdateContent([FromBody] ContentDto contentDto)
        {
            var result = await _contentService.UpdateContent(contentDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete]
        [Route("DeleteContent/{id}")]
        public async Task<IActionResult> DeleteContent(int id)
        {
            var result = await _contentService.DeleteContent(id);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result.ErrorMessage);
        }
        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search([FromBody] SearchContentRequest request)
        {
            var result = await _contentService.SearchContents(request);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}

