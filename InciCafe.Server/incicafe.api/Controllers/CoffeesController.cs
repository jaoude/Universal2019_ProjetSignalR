using InciCafe.BLL.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CoffeesController : ControllerBase
    {
        // GET api/values
        private readonly ICoffeeService _coffeeService;


        public CoffeesController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet]

        public async Task<ActionResult> Get(CancellationToken ct)
        {
            var liste = await _coffeeService.GetCoffeesAsync(ct);
            return Ok(liste);

        }

        
        [Route("coffees/{name}")]
       
        public async Task<int> GetAsync(string name, CancellationToken ct)
        {
            var liste = await _coffeeService.GetCoffeeAsync(name, ct);
            return liste.Id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpGet("{id}")]
    
       public async Task<string> GetCoffeeAsync(int id ,CancellationToken ct)
        {
            var liste = await _coffeeService.GetCoffeeAsync(id, ct);
            return liste.name;

        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
