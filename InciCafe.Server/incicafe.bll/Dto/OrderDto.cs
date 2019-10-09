using System;
using System.Collections.Generic;
using System.Text;

namespace InciCafe.BLL.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int Client_Id { get; set; }

        public int Coffee_Id { get; set; }

        public DateTime Created_At { get; set; }

        public int Status_Id { get; set; }


    }
}
