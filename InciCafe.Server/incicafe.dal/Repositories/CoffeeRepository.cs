using InciCafe.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.Repositories
{
    public class CoffeeRepository : Repository<Coffee>, ICoffeeRepository
    {
        //private CoffeeContext _context;

        public CoffeeRepository(InciCafeDbContext _db) : base(_db)
        {


        }
        public async Task<Coffee> GetCoffeeAsync(int id, CancellationToken ct)
        {
            return await _db.Set<Coffee>().FirstOrDefaultAsync(ct);
        }

        public async Task<IEnumerable<Coffee>> GetCoffeesAsync(CancellationToken ct)
        {
            return await _db.Set<Coffee>().ToListAsync(ct);
        }

        public void CreateCoffee(Coffee  CoffeeEntity)
        {
            _db.Set<Coffee>().Add(CoffeeEntity);
        }

        public async Task<Coffee> GetCoffeeAsync(string name, CancellationToken ct)
        {
            return await _db.Set<Coffee>().FirstOrDefaultAsync(d => d.Name == name, ct);
        }
    }
}
