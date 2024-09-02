using AutoMapper.Internal.Mappers;
using Zarani.Application.Mapper;
using Zarani.Common.IOC;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Infrastructure.UnitOfWork;

namespace Zarani.Application.Services.Product
{
    public class ProductService : IProductService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<List<ProductDto>>> GetAll()
        {
            var productEntities = (await _unitOfWork.GetRepository<Zarani.Infrastructure.Models.ProductEntity>().GetAllAsync()).ToList();
            var products = ObjectMapper.Mapper.Map<List<ProductDto>>(productEntities);
            return new BaseResponse<List<ProductDto>>()
            {
                Data = products
            };
        }

        // Create
        public async Task<BaseResponse<ProductDto>> AddProduct(ProductDto productDto)
        {
            var product = ObjectMapper.Mapper.Map<Zarani.Infrastructure.Models.ProductEntity>(productDto);
            await _unitOfWork.GetRepository<Zarani.Infrastructure.Models.ProductEntity>().AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<ProductDto>()
            {
                Data = ObjectMapper.Mapper.Map<ProductDto>(product)
            };
        }

        // Read
        public async Task<BaseResponse<ProductDto>> GetProductById(int id)
        {
            var product = await _unitOfWork.GetRepository<Zarani.Infrastructure.Models.ProductEntity>().GetByIdAsync(id);
            var productDto = ObjectMapper.Mapper.Map<ProductDto>(product);
            return new BaseResponse<ProductDto>()
            {
                Data = productDto
            };
        }

        // Update
        public async Task<BaseResponse<ProductDto>> UpdateProduct(ProductDto productDto)
        {
            var product = ObjectMapper.Mapper.Map<Zarani.Infrastructure.Models.ProductEntity>(productDto);
            await _unitOfWork.GetRepository<Zarani.Infrastructure.Models.ProductEntity>().UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<ProductDto>()
            {
                Data = ObjectMapper.Mapper.Map<ProductDto>(product)
            };
        }

        // Delete
        public async Task<BaseResponse<bool>> DeleteProduct(int id)
        {
            var product = await _unitOfWork.GetRepository<Zarani.Infrastructure.Models.ProductEntity>().GetByIdAsync(id);
            if (product != null)
            {
                await _unitOfWork.GetRepository<Zarani.Infrastructure.Models.ProductEntity>().DeleteAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<bool>()
                {
                    Data = true
                };
            }
            return new BaseResponse<bool>()
            {
                Data = false,
                ErrorMessage = "Product not found"
            };
        }
    }
}
