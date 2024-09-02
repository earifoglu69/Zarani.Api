using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Zarani.Api.Controllers;
using Zarani.Application.Services;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Domain.Request;

namespace Zarani.Api.Test.Controller
{
    /// <summary>
    /// Unit tests for the ContentController.
    /// </summary>
    public class ContentControllerTests
    {
        private readonly Mock<IContentService> _contentServiceMock;
        private readonly ContentController _contentController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentControllerTests"/> class.
        /// </summary>
        public ContentControllerTests()
        {
            _contentServiceMock = new Mock<IContentService>();
            _contentController = new ContentController(_contentServiceMock.Object);
        }

        /// <summary>
        /// Tests that GetAllContents returns an Ok result.
        /// </summary>
        [Fact]
        public async Task GetAllContents_ShouldReturnOk()
        {
            // Arrange
            _contentServiceMock.Setup(cs => cs.GetAllContents())
                .ReturnsAsync(new BaseResponse<List<ContentDto>>());

            // Act
            var result = await _contentController.GetAllContents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that AddContent returns an Ok result when the addition is successful.
        /// </summary>
        [Fact]
        public async Task AddContent_ShouldReturnOk_WhenAddIsSuccessful()
        {
            // Arrange
            var contentDto = new ContentDto();
            _contentServiceMock.Setup(cs => cs.AddContent(contentDto))
                .ReturnsAsync(new BaseResponse<ContentDto> { Data = contentDto });

            // Act
            var result = await _contentController.AddContent(contentDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that AddContent returns a BadRequest result when the addition fails.
        /// </summary>
        [Fact]
        public async Task AddContent_ShouldReturnBadRequest_WhenAddFails()
        {
            // Arrange
            var contentDto = new ContentDto();
            _contentServiceMock.Setup(cs => cs.AddContent(contentDto))
                .ReturnsAsync(new BaseResponse<ContentDto> { ErrorMessage = "Error" });

            // Act
            var result = await _contentController.AddContent(contentDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that GetContentById returns an Ok result when the content exists.
        /// </summary>
        [Fact]
        public async Task GetContentById_ShouldReturnOk_WhenContentExists()
        {
            // Arrange
            var contentDto = new ContentDto();
            _contentServiceMock.Setup(cs => cs.GetContentById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<ContentDto> { Data = contentDto });

            // Act
            var result = await _contentController.GetContentById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that GetContentById returns a NotFound result when the content does not exist.
        /// </summary>
        [Fact]
        public async Task GetContentById_ShouldReturnNotFound_WhenContentDoesNotExist()
        {
            // Arrange
            _contentServiceMock.Setup(cs => cs.GetContentById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<ContentDto> { ErrorMessage = "Not Found" });

            // Act
            var result = await _contentController.GetContentById(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Tests that UpdateContent returns an Ok result when the update is successful.
        /// </summary>
        [Fact]
        public async Task UpdateContent_ShouldReturnOk_WhenUpdateIsSuccessful()
        {
            // Arrange
            var contentDto = new ContentDto();
            _contentServiceMock.Setup(cs => cs.UpdateContent(contentDto))
                .ReturnsAsync(new BaseResponse<ContentDto> { Data = contentDto });

            // Act
            var result = await _contentController.UpdateContent(contentDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that UpdateContent returns a BadRequest result when the update fails.
        /// </summary>
        [Fact]
        public async Task UpdateContent_ShouldReturnBadRequest_WhenUpdateFails()
        {
            // Arrange
            var contentDto = new ContentDto();
            _contentServiceMock.Setup(cs => cs.UpdateContent(contentDto))
                .ReturnsAsync(new BaseResponse<ContentDto> { ErrorMessage = "Error" });

            // Act
            var result = await _contentController.UpdateContent(contentDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that DeleteContent returns an Ok result when the deletion is successful.
        /// </summary>
        [Fact]
        public async Task DeleteContent_ShouldReturnOk_WhenDeleteIsSuccessful()
        {
            // Arrange
            _contentServiceMock.Setup(cs => cs.DeleteContent(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool> { Data = true });

            // Act
            var result = await _contentController.DeleteContent(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that DeleteContent returns a NotFound result when the deletion fails.
        /// </summary>
        [Fact]
        public async Task DeleteContent_ShouldReturnNotFound_WhenDeleteFails()
        {
            // Arrange
            _contentServiceMock.Setup(cs => cs.DeleteContent(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool> { ErrorMessage = "Not Found" });

            // Act
            var result = await _contentController.DeleteContent(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Tests that Search returns an Ok result when the search is successful.
        /// </summary>
        [Fact]
        public async Task Search_ShouldReturnOk_WhenSearchIsSuccessful()
        {
            // Arrange
            var request = new SearchContentRequest();
            _contentServiceMock.Setup(cs => cs.SearchContents(request))
                .ReturnsAsync(new BaseResponse<List<ContentDto>> { Data = new List<ContentDto>() });

            // Act
            var result = await _contentController.Search(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that Search returns a BadRequest result when the search fails.
        /// </summary>
        [Fact]
        public async Task Search_ShouldReturnBadRequest_WhenSearchFails()
        {
            // Arrange
            var request = new SearchContentRequest();
            _contentServiceMock.Setup(cs => cs.SearchContents(request))
                .ReturnsAsync(new BaseResponse<List<ContentDto>> { ErrorMessage = "Error" });

            // Act
            var result = await _contentController.Search(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
