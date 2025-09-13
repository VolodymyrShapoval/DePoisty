using AutoMapper;
using DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.Mappers
{
    public class RestaurantMetaProfile : Profile
    {
        public RestaurantMetaProfile()
        {
            CreateMap<RestaurantMeta, RestaurantMetaDTO>();
            CreateMap<CreateRestaurantMetaDTO, RestaurantMeta>();
            CreateMap<UpdateRestaurantMetaDTO, RestaurantMeta>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
