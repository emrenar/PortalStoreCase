using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Entities.DTOs.RequestDtos
{
    public class OrderRequestDto
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
