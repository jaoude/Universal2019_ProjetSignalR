using InciCafe.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.Repositories
{
    public interface ICoffeeRepository : IRepository<Coffee>
    {
        Task<IEnumerable<Coffee>> GetCoffeesAsync(CancellationToken ct);
        Task<Coffee> GetCoffeeAsync(int id, CancellationToken ct);
        Task<Coffee> GetCoffeeAsync(string name, CancellationToken ct);

        void CreateCoffee(Coffee personEntity);
    }
}
