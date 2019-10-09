using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InciCafe.BLL.Dto
{
   public class CreateClientDto
    {
        [Required]
        [MaxLength(25)]

        public string FirstName;

        [Required]
        [MaxLength(25)]
        public string LastName;

        [Required]
        [MaxLength(50)]
        public string Email;

        public int Age;

    }
}
