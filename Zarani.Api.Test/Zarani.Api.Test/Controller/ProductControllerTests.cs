using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Zarani.Api.Controllers;
using Zarani.Application.Services.Product;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;

namespace Zarani.Api.Test.Controller
{
    /// <summary>
    /// Unit tests for the ProductController.
    /// </summary>
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProductController _productController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControllerTests"/> class.
        /// </summary>
        public ProductControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _productController = new ProductController(_productServiceMock.Object);
        }

        /// <summary>
        /// Tests that GetAll returns an Ok result.
        /// </summary>
        [Fact]
        public async Task GetAll_ShouldReturnOk()
        {
            // Arrange
            _productServiceMock.Setup(ps => ps.GetAll())
                .ReturnsAsync(new BaseResponse<List<ProductDto>>());

            // Act
            var result = await _productController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that AddProduct returns an Ok result when the addition is successful.
        /// </summary>
        [Fact]
        public async Task AddProduct_ShouldReturnOk_WhenAddIsSuccessful()
        {
            // Arrange
            var productDto = new ProductDto();
            _productServiceMock.Setup(ps => ps.AddProduct(productDto))
                .ReturnsAsync(new BaseResponse<ProductDto> { Data = productDto });

            // Act
            var result = await _productController.AddProduct(productDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that AddProduct returns a BadRequest result when the addition fails.
        /// </summary>
        [Fact]
        public async Task AddProduct_ShouldReturnBadRequest_WhenAddFails()
        {
            // Arrange
            var productDto = new ProductDto();
            _productServiceMock.Setup(ps => ps.AddProduct(productDto))
                .ReturnsAsync(new BaseResponse<ProductDto> { ErrorMessage = "Error" });

            // Act
            var result = await _productController.AddProduct(productDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that GetProductById returns an Ok result when the product exists.
        /// </summary>
        [Fact]
        public async Task GetProductById_ShouldReturnOk_WhenProductExists()
        {
            // Arrange
            var productDto = new ProductDto();
            _productServiceMock.Setup(ps => ps.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<ProductDto> { Data = productDto });

            // Act
            var result = await _productController.GetProductById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that GetProductById returns a NotFound result when the product does not exist.
        /// </summary>
        [Fact]
        public async Task GetProductById_ShouldReturnNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            _productServiceMock.Setup(ps => ps.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<ProductDto> { ErrorMessage = "Not Found" });

            // Act
            var result = await _productController.GetProductById(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// Tests that UpdateProduct returns an Ok result when the update is successful.
        /// </summary>
        [Fact]
        public async Task UpdateProduct_ShouldReturnOk_WhenUpdateIsSuccessful()
        {
            // Arrange
            var productDto = new ProductDto();
            _productServiceMock.Setup(ps => ps.UpdateProduct(productDto))
                .ReturnsAsync(new BaseResponse<ProductDto> { Data = productDto });

            // Act
            var result = await _productController.UpdateProduct(productDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that UpdateProduct returns a BadRequest result when the update fails.
        /// </summary>
        [Fact]
        public async Task UpdateProduct_ShouldReturnBadRequest_WhenUpdateFails()
        {
            // Arrange
            var productDto = new ProductDto();
            _productServiceMock.Setup(ps => ps.UpdateProduct(productDto))
                .ReturnsAsync(new BaseResponse<ProductDto> { ErrorMessage = "Error" });

            // Act
            var result = await _productController.UpdateProduct(productDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that DeleteProduct returns an Ok result when the deletion is successful.
        /// </summary>
        [Fact]
        public async Task DeleteProduct_ShouldReturnOk_WhenDeleteIsSuccessful()
        {
            // Arrange
            _productServiceMock.Setup(ps => ps.DeleteProduct(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool> { Data = true });

            // Act
            var result = await _productController.DeleteProduct(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests that DeleteProduct returns a NotFound result when the deletion fails.
        /// </summary>
        [Fact]
        public async Task DeleteProduct_ShouldReturnNotFound_WhenDeleteFails()
        {
            // Arrange
            _productServiceMock.Setup(ps => ps.DeleteProduct(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<bool> { ErrorMessage = "Not Found" });

            // Act
            var result = await _productController.DeleteProduct(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        }
        /// <summary>
        /// Tests that GetProductById returns a BadRequest result when the ID is invalid.
        /// </summary>
        [Fact]
        public async Task GetProductById_ShouldReturnBadRequest_WhenIdIsInvalid()
        {
            // Arrange
            _productServiceMock.Setup(ps => ps.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(new BaseResponse<ProductDto> { ErrorMessage = "Not Found" });
            // Act
            var result = await _productController.GetProductById(-1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that AddProduct returns a BadRequest result when the productDto is null.
        /// </summary>
        [Fact]
        public async Task AddProduct_ShouldReturnBadRequest_WhenProductDtoIsNull()
        {
            _productServiceMock.Setup(ps => ps.AddProduct(null))
               .ReturnsAsync(new BaseResponse<ProductDto> { ErrorMessage = "Error" });
            // Act
            var result = await _productController.AddProduct(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Tests that GetAll returns an Ok result with an empty list when there are no products.
        /// </summary>
        [Fact]
        public async Task GetAll_ShouldReturnOk_WithEmptyList()
        {
            // Arrange
            _productServiceMock.Setup(ps => ps.GetAll())
                .ReturnsAsync(new BaseResponse<List<ProductDto>> { Data = new List<ProductDto>() });

            // Act
            var result = await _productController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsType<BaseResponse<List<ProductDto>>>(okResult.Value);
            Assert.Empty(products.Data);
        }
    }
}
