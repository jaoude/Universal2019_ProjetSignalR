using InciCafe.DAL.Repositories;
using InciCafe.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.Repositories
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        //private CoffeeContext context;


        public StatusRepository(InciCafeDbContext _db) : base(_db)
        {

        }

        
        public async Task<Status> GetStatusAsync(int id, CancellationToken ct)
        {
            return await _db.Set<Status>().FirstOrDefaultAsync(d => d.Id == id, ct);
        }

        public async Task<IEnumerable<Status>> GetStatusAsync(CancellationToken ct)
        {
            return await _db.Set<Status>().ToListAsync(ct);
        }

        public void CreateStatus(Status personEntity)
        {
            _db.Set<Status>().Add(personEntity);
        }
        public void Createstatus(Status statusEntity)
        {
            throw new NotImplementedException();
        }

        
    }
}
