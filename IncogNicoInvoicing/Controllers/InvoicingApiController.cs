using Invoicing.Business;
using Invoicing.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IncogNicoInvoicing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicingApiController : ControllerBase
    {
        private DemoDataProvider demoDataProvider;
        public InvoicingApiController()
        {
            demoDataProvider = new DemoDataProvider();
        }

        [HttpGet((nameof(GetCustomers)))]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return demoDataProvider.GetCustomers();
        }

        [HttpGet((nameof(GetMyBusiness)))]
        public BusinessDto GetMyBusiness()
        {
            return demoDataProvider.GetBusiness();
        }

        [HttpGet((nameof(GetWorkItems)))]
        public IEnumerable<WorkItemDto> GetWorkItems()
        {
            return demoDataProvider.GetWorkItems();
        }
    }
}
