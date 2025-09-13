using AutoMapper;
using DePoisty.RestaurantFoodsService.Application.DTOs.Restaurants;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.Mappers
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>();
            CreateMap<Restaurant, RestaurantWithMetaDTO>();
            CreateMap<CreateRestaurantDTO, Restaurant>();
            CreateMap<UpdateRestaurantDTO, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
