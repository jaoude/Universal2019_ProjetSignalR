using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InciCafe.BLL.Dto
{
   public class CreateOrderDto
    {
        public int? ClientId { get; set; }

        public int? CoffeeId { get; set; }

        [Required]
        public string Size { get; set; }
    }
}
