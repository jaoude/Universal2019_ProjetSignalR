using InciCafe.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.Repositories
{
   public interface IStatusRepository : IRepository<Status>
    {
        Task<IEnumerable<Status>> GetStatusAsync(CancellationToken ct);
        Task<Status> GetStatusAsync(Guid id, CancellationToken ct);

        void Createstatus(Status statusEntity);
    }
}
