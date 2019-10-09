using InciCafe.BLL.Dto;
using InciCafe.DAL;
using InciCafe.DAL.Entities;
using InciCafe.DAL.UnitOfWork;
using InciOneSoft.BLL.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
    public class OrderService :ServiceBase, IOrderService
    {
        public OrderService(IUnitOfWork uow, IAutoMapperService mapper, ILogger<CoffeeService> logger) : base(uow, mapper, logger)
        {
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(CancellationToken ct)
        {
            IEnumerable<Order> ordersEntity = await _uow.Orders.GetOrdersAsync(ct);
            IEnumerable<OrderDto> ordersDto = _mapper.Mapper.Map<IEnumerable<OrderDto>>(ordersEntity);
            return ordersDto.ToList();
        }

        public async Task<OrderDto> GetOrderAsync(int id, CancellationToken ct)
        {
            
            Order ordersEntity = await _uow.Orders.GetOrderAsync(id, ct);
            OrderDto ordersDto = _mapper.Mapper.Map<OrderDto>(ordersEntity);
            return ordersDto;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken ct)
        {
            Order ordersEntity = _mapper.Mapper.Map<Order>(createOrderDto);
            _uow.Orders.CreateOrder(ordersEntity);

            if (await _uow.SaveChangesAsync(ct) > 0)
                return ordersEntity.Id;
            else
                return 0;
        }
    }
}
