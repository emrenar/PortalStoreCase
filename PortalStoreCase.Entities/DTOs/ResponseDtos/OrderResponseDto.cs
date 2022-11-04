using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Entities.DTOs.ResponseDtos
{
    public class OrderResponseDto
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
