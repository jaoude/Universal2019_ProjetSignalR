using InciCafe.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.DAL.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetClientsAsync(CancellationToken ct);
        Task<Client> GetClientAsync(int id, CancellationToken ct);

        void CreateClient(Client clientEntity);
    }
}
