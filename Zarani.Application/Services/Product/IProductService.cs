using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;

namespace Zarani.Application.Services.Product
{
    public interface IProductService
    {
        Task<BaseResponse<List<ProductDto>>> GetAll();
        Task<BaseResponse<ProductDto>> AddProduct(ProductDto productDto);
        Task<BaseResponse<ProductDto>> GetProductById(int id);
        Task<BaseResponse<ProductDto>> UpdateProduct(ProductDto productDto);
        Task<BaseResponse<bool>> DeleteProduct(int id);
    }
}
