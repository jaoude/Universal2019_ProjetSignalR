using InciCafe.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICoffeeRepository Coffees { get; }

        IClientRepository Clients { get; }

        IOrderRepository Orders { get; }
        
        IStatusRepository Status { get; }

        IStatusRepository Statuses { get; }


        Task<int> SaveChangesAsync(CancellationToken ct);

        int SaveChanges();

    }
}
