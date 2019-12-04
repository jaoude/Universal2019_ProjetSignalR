using InciCafe.Api;
using InciCafe.BLL.Dto;
using InciCafe.BLL.Service;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Access-Control-Allow-Origin")]
    public class OrdersController : ControllerBase
    {

        public readonly IHubContext<ChatHub> hubContext;
        // GET api/values
        private readonly IOrderService _orderService;
        private readonly IHubContext<ChatHub> _hubContext;



        public OrdersController(IOrderService orderService,IHubContext<ChatHub> hubContext)
        {
            _orderService = orderService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken ct)
        {
            var liste = await _orderService.GetOrdersAsync(ct);
            return Ok(liste);

        }

        [HttpGet("update")]
        public async Task<ActionResult> UpdateStatus(CancellationToken ct)
        {
            await _orderService.UpdateOrderStatus(ct);


            return Ok();

        }



        // POST api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto order, CancellationToken ct)
        {
            order.ClientId = 1;
          await  _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hello There General Kenobi");



            var orderDto = await _orderService.CreateOrderAsync(order, ct);
            if (orderDto == null)
                return UnprocessableEntity();
            else
                return CreatedAtRoute(new { orderDto.Id }, orderDto);
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
