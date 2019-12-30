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
using InciCafe.DAL.Entities;
using Newtonsoft.Json;

namespace InciCafe.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Access-Control-Allow-Origin")]
    public class OrdersController : ControllerBase
    {


        // GET api/values
        private readonly IOrderService _orderService;

        private readonly IHubContext<ChatHub> _hubContext;




        public OrdersController(IOrderService orderService, IHubContext<ChatHub> hubContext)
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
            var liste = await _orderService.GetOrdersAsync(ct);


            foreach (OrderDto i in liste)
            {
                var item = await _orderService.UpdateOrderStatus(i.Id, ct);
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "never underestimate a droid");
            }




            return Ok();

        }
        [HttpGet("RandomPost")]

        public async Task<IActionResult> CreateOrder(CancellationToken ct)
        {


            int[] ClientsId = { 3, 4, 5, 6 };
            int[] CoffeesId = { 1, 2, 3, 4 }; 
            string[] Sizes = { "S", "M", "L", "XL" };

            Random r = new Random();
            int value = ClientsId[r.Next(ClientsId.Length - 1)];
            string sizes = Sizes[r.Next(Sizes.Length - 1)];
            int coffees = CoffeesId[r.Next(CoffeesId.Length - 1)];
            string json = "{ClientId : " + value + ",\n CoffeeId : " + coffees + ",\n Size : '" + sizes+ "' }";
            var order = JsonConvert.DeserializeObject<CreateOrderDto>(json);









            var orderDto = await _orderService.CreateOrderAsync(order, ct);
            if (orderDto == null)
                return UnprocessableEntity();
            else
            {
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "never underestimate a droid");
                return CreatedAtRoute(new { orderDto.Id }, orderDto);
                
            }
           
        }



        // POST api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto order, CancellationToken ct)
        {





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
