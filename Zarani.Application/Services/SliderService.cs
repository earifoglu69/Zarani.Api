using Zarani.Infrastructure.Models;
using Zarani.Infrastructure.UnitOfWork;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Common.IOC;
using Zarani.Application.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (slider == null)
            {
                return new BaseResponse<SliderDto>
                {
                    ErrorMessage = "Slider not found"
                };
            }
            return new BaseResponse<SliderDto>
            {
                Data = ObjectMapper.Mapper.Map<SliderDto>(slider)
            };
        }

        public async Task<BaseResponse<List<SliderDto>>> GetAllSliders()
        {
            var sliderEntities = await _unitOfWork.GetRepository<SliderEntity>().GetAllAsync();
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
            if (slider == null)
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    ErrorMessage = "Slider not found"
                };
            }
            await _unitOfWork.GetRepository<SliderEntity>().DeleteAsync(slider);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<bool>
            {
                Data = true
            };
        }
    }
}
