using InciCafe.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
    public interface IStatusService
    {
        Task<StatusDto> GetStatusAsync(int id, CancellationToken ct);
    }
}
