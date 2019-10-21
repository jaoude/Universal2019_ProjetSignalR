using InciCafe.DAL.Repositories;
using InciCafe.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InciCafeDbContext _db;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(InciCafeDbContext db,
          IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }
        public ICoffeeRepository Coffees => _serviceProvider.GetService<ICoffeeRepository>();
        public IStatusRepository Statuses => _serviceProvider.GetService<IStatusRepository>();
        public IOrderRepository Orders => _serviceProvider.GetService<IOrderRepository>();
        public IClientRepository Clients => _serviceProvider.GetService<IClientRepository>();
        public IStatusRepository Status => _serviceProvider.GetService<IStatusRepository>();

        public void Dispose()
        {
            _db.Dispose();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return await _db.SaveChangesAsync(ct);
        }

        public int SaveChangesAsync()
        {
            return _db.SaveChanges();
        }
    }
}
