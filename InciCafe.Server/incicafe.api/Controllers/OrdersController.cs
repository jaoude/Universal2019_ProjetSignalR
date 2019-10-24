using InciCafe.BLL.Dto;
using InciCafe.BLL.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class OrdersController : ControllerBase
    {
        // GET api/values
        private readonly IOrderService _orderService;


        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken ct)
        {
            var liste = await _orderService.GetOrdersAsync(ct);
            return Ok(liste);

        }

       

        // POST api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto order, CancellationToken ct)
        {
            var author = await _orderService.CreateOrderAsync(order, ct);
            if (author == null )
                return UnprocessableEntity();
            else
                return CreatedAtRoute( new { author.Id }, author);
        }
      
        // PUT api/orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
