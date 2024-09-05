using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zarani.Application.Services.Slider
{
    public interface ISliderService
    {
        Task<BaseResponse<SliderDto>> AddSlider(SliderDto sliderDto);
        Task<BaseResponse<SliderDto>> GetSliderById(int id);
        Task<BaseResponse<List<SliderDto>>> GetAllSliders();
        Task<BaseResponse<SliderDto>> UpdateSlider(SliderDto sliderDto);
        Task<BaseResponse<bool>> DeleteSlider(int id);
    }
}
