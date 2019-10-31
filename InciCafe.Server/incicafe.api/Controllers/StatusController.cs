using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using InciCafe.BLL.Dto;
using InciCafe.BLL.Service;
using System.Threading;

namespace InciCafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService _statusService)
        {
            this._statusService = _statusService;
        }
        [HttpGet("{id}")]
        public async Task<string> GetStatusAsync(int id, CancellationToken ct)
        {
            var liste = await _statusService.GetStatusAsync(id, ct);
            return liste.Name;
        }
       

    }
}