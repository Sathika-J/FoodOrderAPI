using AutoMapper;
using FoodOrderApi.Model.Domain;
using FoodOrderApi.Model.DTO;

namespace FoodOrderApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Menu, MenuDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.Id)); ;
            CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
            CreateMap<Restaurant, DisplayRestaurantDTO>().ReverseMap();
            CreateMap<Menu, DisplayMenuDTO>().ReverseMap();
            CreateMap<Order, GetOrderDTO>().ReverseMap();
        }
    }
}