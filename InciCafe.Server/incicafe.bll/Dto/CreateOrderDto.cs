using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InciCafe.BLL.Dto
{
   public class CreateOrderDto
    {
        [Required]
        public int Client_Id;

        [Required]

        public int Coffee_Id;

        [Required]

        public DateTime Created_At;

        [Required]

        public int Status_Id;
    }
}
