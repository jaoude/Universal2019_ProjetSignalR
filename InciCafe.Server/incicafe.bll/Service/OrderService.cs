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

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken ct)
        {
            Order orderEntity = _mapper.Mapper.Map<Order>(createOrderDto);
            orderEntity.CreatedAt = DateTime.UtcNow;
            orderEntity.StatusId = 1;

            _uow.Orders.CreateOrder(orderEntity);

            if (await _uow.SaveChangesAsync(ct) > 0)
            {
                var ordeEntitySaved = await _uow.Orders.GetOrderAsync(orderEntity.Id, ct);
                var orderDto = _mapper.Mapper.Map<OrderDto>(ordeEntitySaved);
                return orderDto;
            }
            else
            {
                throw new Exception("An error occured while creating the coffee order.");
            }
        }

        public  async Task<Order> UpdateOrderStatus(int id,CancellationToken ct)
        {
             Order order = await _uow.Orders.UpdateStatus(id,ct);
            return order;
        }
    }
}
