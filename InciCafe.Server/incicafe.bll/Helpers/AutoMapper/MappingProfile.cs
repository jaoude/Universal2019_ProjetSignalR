using AutoMapper;
using InciCafe.BLL;
using InciCafe.BLL.Dto;
using InciCafe.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InciOneSoft.BLL.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coffee, CoffeeDto>();
            CreateMap<CreateCoffeeDto, Coffee>();
            CreateMap<Client, ClientDto>();
            CreateMap<Status, StatusDto>();
            CreateMap<CreateClientDto, Client>();
            CreateMap<Order, OrderDto>()
                  .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name))
                  .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src =>
                                string.Format("{0} {1}", src.Client.FirstName, src.Client.LastName)))
                 .ForMember(dest => dest.CoffeeName, opt => opt.MapFrom(src => src.Coffee.Name));
            CreateMap<CreateOrderDto, Order>(); 
        }
    }
}
