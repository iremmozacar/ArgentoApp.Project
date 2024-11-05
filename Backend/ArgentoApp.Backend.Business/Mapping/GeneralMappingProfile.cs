using ArgentoApp.Backend.Entity.Concrete;
using ArgentoApp.Backend.Entity.Concrete.Abstact;
using ArgentoApp.Backend.Shared.DTOs;
using ArgentoApp.Backend.Shared.DTOs.CartDTOs;
using ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;
using ArgentoApp.Backend.Shared.DTOs.Categories;
using ArgentoApp.Backend.Shared.DTOs.CategoryDto;
using ArgentoApp.Backend.Shared.DTOs.CategoryDTOs;
using ArgentoApp.Backend.Shared.DTOs.OrderDTOs;

using ArgentoApp.Backend.Shared.DTOs.ProductDTOs;
using AutoMapper;

namespace ArgentoApp.Backend.Business.Mapping;

public class GeneralMappingProfile : Profile
{
    public GeneralMappingProfile()
    {
        //Category>>>
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        //Product>>>
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        //Cart>>>
        CreateMap<Cart, CartDto>().ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems));
        CreateMap<Cart, CartCreateDto>().ReverseMap();
        CreateMap<Cart, CartUpdateDto>().ReverseMap();
        //CartItem>>>
        CreateMap<CartItem, CartItemDto>().ReverseMap();
        CreateMap<CartItem, CartItemCreateDto>().ReverseMap();
        CreateMap<CartItem, CartItemUpdateDto>().ReverseMap();
        //Order>>>
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderCreateDto>().ReverseMap();

        //OrderItem>>>
        CreateMap<OrderItem, OrderItemDto>().ReverseMap().ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));
        CreateMap<Order, InOrderItemOrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap();






    }


}
