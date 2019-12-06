using InciCafe.DAL.Entities;
using InciCafe.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
namespace InciCafe.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        //private CoffeeContext _context;


       // private readonly IHubContext<ChatHub> _hubContext;




        public OrderRepository(InciCafeDbContext _db) : base(_db)
        {
           // _hubContext = hubContext;
        }
        public async Task<Order> GetOrderAsync(int id, CancellationToken ct) => 
            await _db.Set<Order>()
            .Include(c => c.Coffee)
            .Include(c => c.Client)
            .Include(c => c.Status)
            .FirstOrDefaultAsync (c => c.Id == id, ct);

        public async Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken ct)
        {
            return await _db.Set<Order>()
            .Include(c => c.Coffee)
            .Include(c => c.Client)
            .Include(c => c.Status)
            .ToListAsync(ct);
        }

        public void CreateOrder(Order orderEntity)
        {
            _db.Set<Order>().Add(orderEntity);
        }

        public async Task<Order> UpdateStatus(int id,CancellationToken ct)
        {
         Order order = await GetOrderAsync(id,ct);
            if (order.StatusId < 3)
            {
                order.StatusId += 1;
                _db.Set<Order>().Update(order);
            }
            else
            {
                _db.Set<Order>().Remove(order);
            }
            


            await _db.SaveChangesAsync(ct);
            return order;
           

        /*    Random r = new Random();
         //  await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hello There General Kenobi");


            foreach (var item in liste)
            {
                int val = r.Next(1, 3);
                item.StatusId = val;
                _db.Set<Order>().Update(item);
               

                await _db.SaveChangesAsync(ct);
               
            }*/

         

         


          



          

           
        }
    }
}
