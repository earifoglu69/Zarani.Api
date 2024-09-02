using Zarani.Infrastructure.Models;
using Zarani.Infrastructure.UnitOfWork;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Common.IOC;
using Zarani.Application.Mapper;
using System.Linq.Expressions;
using Zarani.Domain.Request;

namespace Zarani.Application.Services.Content
{
    public class ContentService : IContentService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Create
        public async Task<BaseResponse<ContentDto>> AddContent(ContentDto contentDto)
        {
            var content = ObjectMapper.Mapper.Map<ContentEntity>(contentDto);
            await _unitOfWork.GetRepository<ContentEntity>().AddAsync(content);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<ContentDto>()
            {
                Data = ObjectMapper.Mapper.Map<ContentDto>(content)
            };
        }

        // Read
        public async Task<BaseResponse<ContentDto>> GetContentById(int id)
        {
            var content = await _unitOfWork.GetRepository<ContentEntity>().GetByIdAsync(id);
            var contentDto = ObjectMapper.Mapper.Map<ContentDto>(content);
            return new BaseResponse<ContentDto>()
            {
                Data = contentDto
            };
        }

        public async Task<BaseResponse<List<ContentDto>>> GetAllContents()
        {
            var contentEntities = (await _unitOfWork.GetRepository<ContentEntity>().GetAllAsync()).ToList();
            var contents = ObjectMapper.Mapper.Map<List<ContentDto>>(contentEntities);
            return new BaseResponse<List<ContentDto>>()
            {
                Data = contents
            };
        }

        // Update
        public async Task<BaseResponse<ContentDto>> UpdateContent(ContentDto contentDto)
        {
            var content = ObjectMapper.Mapper.Map<ContentEntity>(contentDto);
            await _unitOfWork.GetRepository<ContentEntity>().UpdateAsync(content);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<ContentDto>()
            {
                Data = ObjectMapper.Mapper.Map<ContentDto>(content)
            };
        }

        // Delete
        public async Task<BaseResponse<bool>> DeleteContent(int id)
        {
            var content = await _unitOfWork.GetRepository<ContentEntity>().GetByIdAsync(id);
            if (content != null)
            {
                await _unitOfWork.GetRepository<ContentEntity>().DeleteAsync(content);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<bool>()
                {
                    Data = true
                };
            }
            return new BaseResponse<bool>()
            {
                Data = false,
                ErrorMessage = "Content not found"
            };
        }
        // Search
        public async Task<BaseResponse<List<ContentDto>>> SearchContents(SearchContentRequest request)
        {
            Expression<Func<ContentEntity, bool>> filter = content =>
                (!request.Id.HasValue || content.Id == request.Id.Value) &&
                (!request.ParentId.HasValue || content.ParentId == request.ParentId.Value) &&
                (!request.ModuleId.HasValue || content.ModuleId == request.ModuleId.Value) &&
                (string.IsNullOrEmpty(request.Permalink) || content.Permalink == request.Permalink) &&
                (!request.HeaderId.HasValue || content.HeaderId == request.HeaderId.Value);

            var contentEntities = (await _unitOfWork.GetRepository<ContentEntity>().GetAllAsync(filter)).ToList();
            var contents = ObjectMapper.Mapper.Map<List<ContentDto>>(contentEntities);
            return new BaseResponse<List<ContentDto>>()
            {
                Data = contents
            };
        }
    }
}
