using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Zarani.Api.Controllers;
using Zarani.Application.Services.Module;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;

namespace Zarani.Api.Test.Controller
{
    /// <summary>
    /// Unit tests for the ModuleController.
    /// </summary>
    public class ModuleControllerTests
    {


        private readonly Mock<IModuleService> _moduleServiceMock;
        private readonly ModuleController _moduleController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleControllerTests"/> class.
        /// </summary>
        public ModuleControllerTests()
        {
            _moduleServiceMock = new Mock<IModuleService>();
            _moduleController = new ModuleController(_moduleServiceMock.Object);
        }

        /// <summary>
        /// Tests that GetAllModules returns an Ok result.
        /// </summary>
        [Fact]
        public async Task GetAllModules_ShouldReturnOk()
        {
            // Arrange
            _moduleServiceMock.Setup(ms => ms.GetAllModules())
                .ReturnsAsync(new BaseResponse<List<ModuleDto>>());

            // Act
            var result = await _moduleController.GetAllModules();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that AddModule returns an Ok result when the addition is successful.
        /// </summary>
        [Fact]
        public async Task AddModule_ShouldReturnOk_WhenAddIsSuccessful()
        {
            // Arrange
            var moduleDto = new ModuleDto();
            _moduleServiceMock.Setup(ms => ms.AddModule(moduleDto))
                .ReturnsAsync(new BaseResponse<ModuleDto> { Data = moduleDto });

            // Act
            var result = await _moduleController.AddModule(moduleDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that AddModule returns a BadRequest result when the addition fails.
        /// </summary>
        [Fact]
        public async Task AddModule_ShouldReturnBadRequest_WhenAddFails()
        {
            // Arrange
            var moduleDto = new ModuleDto();
            _moduleServiceMock.Setup(ms => ms.AddModule(moduleDto))
                .ReturnsAsync(new BaseResponse<ModuleDto> { ErrorMessage = "Error" });

            // Act
            var result = await _moduleController.AddModule(moduleDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that GetModuleById returns an Ok result when the module exists.
        /// </summary>
        [Fact]
        public async Task GetModuleById_ShouldReturnOk_WhenModuleExists()
        {
            // Arrange
            var moduleDto = new ModuleDto();
            _moduleServiceMock.Setup(ms => ms.GetModuleById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<ModuleDto> { Data = moduleDto });

            // Act
            var result = await _moduleController.GetModuleById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that GetModuleById returns a NotFound result when the module does not exist.
        /// </summary>
        [Fact]
        public async Task GetModuleById_ShouldReturnNotFound_WhenModuleDoesNotExist()
        {
            // Arrange
            _moduleServiceMock.Setup(ms => ms.GetModuleById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<ModuleDto> { ErrorMessage = "Not Found" });

            // Act
            var result = await _moduleController.GetModuleById(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Tests that UpdateModule returns an Ok result when the update is successful.
        /// </summary>
        [Fact]
        public async Task UpdateModule_ShouldReturnOk_WhenUpdateIsSuccessful()
        {
            // Arrange
            var moduleDto = new ModuleDto();
            _moduleServiceMock.Setup(ms => ms.UpdateModule(moduleDto))
                .ReturnsAsync(new BaseResponse<ModuleDto> { Data = moduleDto });

            // Act
            var result = await _moduleController.UpdateModule(moduleDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that UpdateModule returns a BadRequest result when the update fails.
        /// </summary>
        [Fact]
        public async Task UpdateModule_ShouldReturnBadRequest_WhenUpdateFails()
        {
            // Arrange
            var moduleDto = new ModuleDto();
            _moduleServiceMock.Setup(ms => ms.UpdateModule(moduleDto))
                .ReturnsAsync(new BaseResponse<ModuleDto> { ErrorMessage = "Error" });

            // Act
            var result = await _moduleController.UpdateModule(moduleDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that DeleteModule returns an Ok result when the deletion is successful.
        /// </summary>
        [Fact]
        public async Task DeleteModule_ShouldReturnOk_WhenDeleteIsSuccessful()
        {
            // Arrange
            _moduleServiceMock.Setup(ms => ms.DeleteModule(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool> { Data = true });

            // Act
            var result = await _moduleController.DeleteModule(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that DeleteModule returns a NotFound result when the deletion fails.
        /// </summary>
        [Fact]
        public async Task DeleteModule_ShouldReturnNotFound_WhenDeleteFails()
        {
            // Arrange
            _moduleServiceMock.Setup(ms => ms.DeleteModule(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool> { ErrorMessage = "Not Found" });

            // Act
            var result = await _moduleController.DeleteModule(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
