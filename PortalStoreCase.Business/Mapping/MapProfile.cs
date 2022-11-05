using AutoMapper;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Customer
            CreateMap<Customer, CustomerResponseDto>().ReverseMap();
            CreateMap<CustomerRequestDto, Customer>().ReverseMap().ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => (src.Birthdate.Date.ToString("dd/MM/yyyy"))));
            //Category
            CreateMap<CategoryResponseDto, Category>().ReverseMap();
            CreateMap<Category, CategoryWithSkuResponseDto>().ReverseMap();
            CreateMap<CategoryRequestDto, Category>().ReverseMap();
            //Sku
            CreateMap<SKU, SkuResponseDto>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<SkuRequestDto, SKU>().ReverseMap();
            //Order
            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<OrderRequestDto, Order>().ReverseMap();
            //OrderItem
            CreateMap<OrderItem, OrderItemResponseDto>()
                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU.Name));
            CreateMap<OrderItemRequestDto, OrderItem>().ReverseMap();
            //Address
            CreateMap<Address, AddressResponseDto>().ForMember(dest => dest.Customer, opt => opt.MapFrom(src => (src.Customer.FirstName + " " + src.Customer.LastName)));
            CreateMap<AddressRequestDto, Address>().ReverseMap();
            CreateMap<AddressPostDto, Address>().ReverseMap();
        }
    }
}
