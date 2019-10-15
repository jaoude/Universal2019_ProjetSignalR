using System;
using System.Collections.Generic;
using System.Text;

namespace InciCafe.BLL.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int CoffeeId { get; set; }

        public DateTime CreatedAt { get; set; }


        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string ClientName { get; set; }

        public string CoffeeName { get; set; }

        public string Size { get; set; }
    }
}
