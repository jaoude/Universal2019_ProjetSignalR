using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InciCafe.DAL.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}

        public DateTime created_at { get; set; }

        [ForeignKey("Client_Id")]
        public Client Client { get; set; }
        public int Client_Id { get; set; }

        [ForeignKey("Coffee_Id")]
        public Coffee Coffee { get; set; }
        public int Coffee_Id { get; set; }

        [ForeignKey("Status_Id")]
        public Status Status { get; set; }
        public int Status_Id { get; set; }

    }
}
