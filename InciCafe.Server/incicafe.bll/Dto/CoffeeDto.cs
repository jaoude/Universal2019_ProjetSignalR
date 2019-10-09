using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InciCafe.BLL
{
    public class CoffeeDto
    {

        public string name { get; set; }
 
        public ICollection<CoffeeDto> Coffees;
       
        
    }
}
