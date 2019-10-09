using InciCafe.BLL.Dto;
using InciCafe.DAL.Entities;
using InciCafe.DAL.UnitOfWork;
using InciOneSoft.BLL.Helpers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
    public class ClientService : ServiceBase, IClientService
    {
        public ClientService(IUnitOfWork uow, IAutoMapperService mapper, ILogger<ClientService> logger) 
            : base(uow, mapper, logger)
        {
        }

        public async Task<IEnumerable<ClientDto>> GetClientsAsync(CancellationToken ct)
        {
            IEnumerable<Client> clientsEntity = await _uow.Clients.GetClientsAsync(ct);
            IEnumerable<ClientDto> clientsDto = _mapper.Mapper.Map<IEnumerable<ClientDto>>(clientsEntity);
            return clientsDto.ToList();
        }

        public async Task<ClientDto> GetClientAsync(int id, CancellationToken ct)
        {
            Client clientsEntity = await _uow.Clients.GetClientAsync(id, ct);
            ClientDto clientsDto = _mapper.Mapper.Map<ClientDto>(clientsEntity);
            return clientsDto;
        }

        public async Task<int> CreateClientAsync(CreateClientDto createClientDto, CancellationToken ct)
        {
            Client clientsEntity = _mapper.Mapper.Map<Client>(createClientDto);
            _uow.Clients.CreateClient(clientsEntity);

            if (await _uow.SaveChangesAsync(ct) > 0)
                return clientsEntity.Id;
            else
                return 0;
        }

     
    }
}
