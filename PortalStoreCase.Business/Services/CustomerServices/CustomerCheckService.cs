using MernisServiceReference;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.CustomerServices
{
    public class CustomerCheckService : ICustomerCheckService
    {
        public async Task<bool> CheckIsRealPersonAsync(Customer customer)
        {
            var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(customer.TCID, customer.FirstName.ToUpper(), customer.LastName.ToUpper(), customer.Birthdate.Year);
            var result = response.Body.TCKimlikNoDogrulaResult;
            return result;
        }
    }
}
