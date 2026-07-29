using Invoicing.Business;
using Invoicing.Contract;
using Invoicing.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IncogNicoInvoicing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicingApiController : ControllerBase
    {
        private IDemoDataProvider _demoDataProvider;
        public InvoicingApiController(IDemoDataProvider demoDataProvider)
        {
            _demoDataProvider = demoDataProvider;
        }

        [HttpGet((nameof(GetCustomers)))]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _demoDataProvider.GetCustomers();
        }

        [HttpGet((nameof(GetMyBusiness)))]
        public BusinessDto GetMyBusiness()
        {
            return _demoDataProvider.GetBusiness();
        }

        [HttpGet((nameof(GetWorkItems)))]
        public IEnumerable<WorkItemDto> GetWorkItems()
        {
            return _demoDataProvider.GetWorkItems();
        }
    }
}
