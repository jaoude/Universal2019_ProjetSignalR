using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InciCafe.BLL.Dto
{
   public class CreateOrderDto
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int CoffeeId { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}
