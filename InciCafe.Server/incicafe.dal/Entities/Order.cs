using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InciCafe.DAL.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}

        public DateTime CreatedAt { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("CoffeeId")]
        public Coffee Coffee { get; set; }
        public int CoffeeId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int StatusId { get; set; }


        
        public string Size { get; set; }

        

    }
}
