using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InciCafe.BLL.Dto
{
   public class CreateCoffeeDto
    {
        [Required]
        [MaxLength(25)]

        public string Name { get; set; }


      
    }
}
