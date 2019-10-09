using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InciCafe.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InciCafe.DAL.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        //private CoffeeContext _context;

        public ClientRepository(InciCafeDbContext _db) : base(_db)
        {
           
        }
        public async Task<Client> GetClientAsync(int id, CancellationToken ct)
        {
            return await _db.Set<Client>().FirstOrDefaultAsync(ct);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(CancellationToken ct)
        {
            return await _db.Set<Client>().ToListAsync(ct);
        }

        public void CreateClient(Client personEntity)
        {
            _db.Set<Client>().Add(personEntity);
        }

       

      

      
    }
}
