using Zarani.Infrastructure.Models;
using Zarani.Infrastructure.UnitOfWork;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Common.IOC;
using Zarani.Application.Mapper;

namespace Zarani.Application.Services.Module
{
    public class ModuleService : IModuleService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Create
        public async Task<BaseResponse<ModuleDto>> AddModule(ModuleDto moduleDto)
        {
            var module = ObjectMapper.Mapper.Map<ModuleEntity>(moduleDto);
            await _unitOfWork.GetRepository<ModuleEntity>().AddAsync(module);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<ModuleDto>()
            {
                Data = ObjectMapper.Mapper.Map<ModuleDto>(module)
            };
        }

        // Read
        public async Task<BaseResponse<ModuleDto>> GetModuleById(int id)
        {
            var module = await _unitOfWork.GetRepository<ModuleEntity>().GetByIdAsync(id);
            var moduleDto = ObjectMapper.Mapper.Map<ModuleDto>(module);
            return new BaseResponse<ModuleDto>()
            {
                Data = moduleDto
            };
        }

        public async Task<BaseResponse<List<ModuleDto>>> GetAllModules()
        {
            var moduleEntities = (await _unitOfWork.GetRepository<ModuleEntity>().GetAllAsync()).ToList();
            var modules = ObjectMapper.Mapper.Map<List<ModuleDto>>(moduleEntities);
            return new BaseResponse<List<ModuleDto>>()
            {
                Data = modules
            };
        }

        // Update
        public async Task<BaseResponse<ModuleDto>> UpdateModule(ModuleDto moduleDto)
        {
            var module = ObjectMapper.Mapper.Map<ModuleEntity>(moduleDto);
            await _unitOfWork.GetRepository<ModuleEntity>().UpdateAsync(module);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<ModuleDto>()
            {
                Data = ObjectMapper.Mapper.Map<ModuleDto>(module)
            };
        }

        // Delete
        public async Task<BaseResponse<bool>> DeleteModule(int id)
        {
            var module = await _unitOfWork.GetRepository<ModuleEntity>().GetByIdAsync(id);
            if (module != null)
            {
                await _unitOfWork.GetRepository<ModuleEntity>().DeleteAsync(module);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<bool>()
                {
                    Data = true
                };
            }
            return new BaseResponse<bool>()
            {
                Data = false,
                ErrorMessage = "Module not found"
            };
        }
    }
}
