using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using InciCafe.BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace InciCafe.Api.Controllers
{

    [Route("api/status")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class StatusController : Controller
    {
        // GET api/values
        private readonly IStatusService _statusService;


        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        [Route("coffees/{id}")]

        public async Task<int> GetStatusAsync(int id, CancellationToken ct)
        {
            var liste = await _statusService.GetStatusAsync(id, ct);
            return liste.Id;
        }
    }

}