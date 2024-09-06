using Zarani.Application.Mapper;
using Zarani.Common.IOC;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Infrastructure.UnitOfWork;
using Zarani.Infrastructure.Models;

namespace Zarani.Application.Services.Slider
{
    public class SliderService : ISliderService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SliderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Create
        public async Task<BaseResponse<SliderDto>> AddSlider(SliderDto sliderDto)
        {
            var slider = ObjectMapper.Mapper.Map<SliderEntity>(sliderDto);
            await _unitOfWork.GetRepository<SliderEntity>().AddAsync(slider);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<SliderDto>
            {
                Data = ObjectMapper.Mapper.Map<SliderDto>(slider)
            };
        }

        // Read
        public async Task<BaseResponse<SliderDto>> GetSliderById(int id)
        {
            var slider = await _unitOfWork.GetRepository<SliderEntity>().GetByIdAsync(id);
            var sliderDto = ObjectMapper.Mapper.Map<SliderDto>(slider);
            return new BaseResponse<SliderDto>
            {
                Data = sliderDto
            };
        }

        public async Task<BaseResponse<List<SliderDto>>> GetAllSliders()
        {
            var sliderEntities = (await _unitOfWork.GetRepository<SliderEntity>().GetAllAsync()).ToList();
            var sliders = ObjectMapper.Mapper.Map<List<SliderDto>>(sliderEntities);
            return new BaseResponse<List<SliderDto>>
            {
                Data = sliders
            };
        }

        // Update
        public async Task<BaseResponse<SliderDto>> UpdateSlider(SliderDto sliderDto)
        {
            var slider = ObjectMapper.Mapper.Map<SliderEntity>(sliderDto);
            await _unitOfWork.GetRepository<SliderEntity>().UpdateAsync(slider);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<SliderDto>
            {
                Data = ObjectMapper.Mapper.Map<SliderDto>(slider)
            };
        }

        // Delete
        public async Task<BaseResponse<bool>> DeleteSlider(int id)
        {
            var slider = await _unitOfWork.GetRepository<SliderEntity>().GetByIdAsync(id);
            if (slider != null)
            {
                await _unitOfWork.GetRepository<SliderEntity>().DeleteAsync(slider);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<bool>
                {
                    Data = true
                };
            }
            return new BaseResponse<bool>
            {
                Data = false,
                ErrorMessage = "Slider not found"
            };
        }
    }
}
