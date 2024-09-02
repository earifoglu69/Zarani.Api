using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zarani.Application.Services.Module
{
    public interface IModuleService
    {
        Task<BaseResponse<ModuleDto>> AddModule(ModuleDto moduleDto);
        Task<BaseResponse<ModuleDto>> GetModuleById(int id);
        Task<BaseResponse<List<ModuleDto>>> GetAllModules();
        Task<BaseResponse<ModuleDto>> UpdateModule(ModuleDto moduleDto);
        Task<BaseResponse<bool>> DeleteModule(int id);
    }
}
