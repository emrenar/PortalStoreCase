﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Entities.Entities
{
    public class Order : BaseEntity
    {
        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
