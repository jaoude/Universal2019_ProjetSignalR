using InciCafe.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        //private CoffeeContext _context;

        public OrderRepository(InciCafeDbContext _db) : base(_db)
        {

        }
        public async Task<Order> GetOrderAsync(int id, CancellationToken ct) => await _db.Set<Order>().FirstOrDefaultAsync(ct);

        public async Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken ct)
        {
            return await _db.Set<Order>().ToListAsync(ct);
        }

        public void CreateOrder(Order personEntity)
        {
            _db.Set<Order>().Add(personEntity);
        }

    }
}
