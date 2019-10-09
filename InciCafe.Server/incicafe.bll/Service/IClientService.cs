using InciCafe.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClientsAsync(CancellationToken ct);
        Task<ClientDto> GetClientAsync(int id, CancellationToken ct);
        Task<int> CreateClientAsync(CreateClientDto createClientDto, CancellationToken ct);
    }
}
