using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Domain.Request;

namespace Zarani.Application.Services
{
    public interface IContentService
    {
        Task<BaseResponse<ContentDto>> AddContent(ContentDto contentDto);
        Task<BaseResponse<ContentDto>> GetContentById(int id);
        Task<BaseResponse<List<ContentDto>>> GetAllContents();
        Task<BaseResponse<ContentDto>> UpdateContent(ContentDto contentDto);
        Task<BaseResponse<bool>> DeleteContent(int id);
        Task<BaseResponse<List<ContentDto>>> SearchContents(SearchContentRequest request);
    }
}
