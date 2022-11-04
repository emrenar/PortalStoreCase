using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Entities.DTOs.ResponseDtos
{
    public class OrderItemResponseDto
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
