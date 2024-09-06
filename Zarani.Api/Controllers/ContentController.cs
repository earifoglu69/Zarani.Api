using Microsoft.AspNetCore.Mvc;
using Zarani.Application.Services;
using Zarani.Domain.Dtos;
using Zarani.Domain.Request;

namespace Zarani.Api.Controllers
{
    /// <summary>
    /// Controller for managing content-related operations.
    /// </summary>
    public class ContentController : BaseController<ContentController>
    {
        private readonly IContentService _contentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentController"/> class.
        /// </summary>
        /// <param name="contentService">The content service.</param>
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        /// <summary>
        /// Gets all contents.
        /// </summary>
        /// <returns>A list of all contents.</returns>
        [HttpPost]
        [Route("GetAllContents")]
        public async Task<IActionResult> GetAllContents()
        {
            return Ok(await _contentService.GetAllContents());
        }

        /// <summary>
        /// Adds new content.
        /// </summary>
        /// <param name="contentDto">The content DTO.</param>
        /// <returns>The result of the add operation.</returns>
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

        /// <summary>
        /// Gets content by identifier.
        /// </summary>
        /// <param name="id">The content identifier.</param>
        /// <returns>The content with the specified identifier.</returns>
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

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="contentDto">The content DTO.</param>
        /// <returns>The result of the update operation.</returns>
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

        /// <summary>
        /// Deletes the content by identifier.
        /// </summary>
        /// <param name="id">The content identifier.</param>
        /// <returns>The result of the delete operation.</returns>
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

        /// <summary>
        /// Searches for contents based on the specified request.
        /// </summary>
        /// <param name="request">The search content request.</param>
        /// <returns>The search results.</returns>
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

