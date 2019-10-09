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
            CreateMap<CreateClientDto, Client>();
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>(); 



            

        }
    }
}
