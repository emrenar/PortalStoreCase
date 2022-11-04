using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Entities.DTOs.RequestDtos
{
    public class CustomerRequestDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long TCID { get; set; }

        public string Birthdate { get; set; }

        public string Gsm { get; set; }
    }
}
