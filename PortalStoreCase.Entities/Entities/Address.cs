﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Entities.Entities
{
    public class Address : BaseEntity
    {
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ZipCode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
