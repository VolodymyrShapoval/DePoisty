using AutoMapper;
using DePoisty.RestaurantFoodsService.Application.DTOs.Dishes;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.Mappers
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDTO>();
            CreateMap<CreateDishDTO, Dish>();
            CreateMap<UpdateDishDTO, Dish>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
