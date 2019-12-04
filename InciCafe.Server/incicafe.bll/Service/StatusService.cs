using InciCafe.BLL.Dto;
using InciCafe.DAL.Entities;
using InciCafe.DAL.UnitOfWork;
using InciOneSoft.BLL.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
   public class StatusService : ServiceBase,IStatusService
    {
        public StatusService(IUnitOfWork uow, IAutoMapperService mapper, ILogger<CoffeeService> logger) : base(uow, mapper, logger)
        {
        }
        public async Task<StatusDto> GetStatusAsync(int id, CancellationToken ct)
        {
            Status statusEntity = await _uow.Status.GetStatusAsync(id, ct);
            StatusDto statusDto = _mapper.Mapper.Map<StatusDto>(statusEntity);
            return statusDto;
        }
    }
}
