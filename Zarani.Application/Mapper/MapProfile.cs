using AutoMapper;
using Zarani.Domain.Dtos;
using Zarani.Infrastructure.Models;

namespace Zarani.Application.Mapper
{
    public sealed class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, ProductEntity>();
            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ContentEntity, ContentDto>();
            CreateMap<ContentDto, ContentEntity>();
            CreateMap<ModuleDto, ModuleEntity>();
            CreateMap<ModuleEntity, ModuleDto>();
            CreateMap<SliderDto, SliderEntity>();
            CreateMap<SliderEntity, SliderDto>();
        }
    }
}
