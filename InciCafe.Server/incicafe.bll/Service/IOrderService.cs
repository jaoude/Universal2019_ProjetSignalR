using InciCafe.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync(CancellationToken ct);
        Task<OrderDto> GetOrderAsync(int id, CancellationToken ct);
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken ct);
    }
}
