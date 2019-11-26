using InciCafe.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.Repositories
{
    public interface IOrderRepository : IRepository<Order>

    {
        Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken ct);
        Task<Order> GetOrderAsync(int id, CancellationToken ct);

        void CreateOrder(Order orderEntity);

        Task UpdateStatus(CancellationToken ct);
    }
}
