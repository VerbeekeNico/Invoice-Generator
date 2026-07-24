using Invoicing.Contract.Dtos;
using Invoicing.Domain.Entities;
using Invoicing.Infrastructure;

namespace Invoicing.Business
{
    public class DemoDataProvider
    {
        private DemoRepository _demoRepo = new DemoRepository();
        private DemoDataDtoMapper _demoMapper = new DemoDataDtoMapper();
        public DemoDataProvider() { }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _demoRepo.GetCustomers();
            var customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                customerDtos.Add(_demoMapper.MapCustomerToDto(customer));
            }

            return customerDtos;
        }

        public BusinessDto GetBusiness()
        {
            return _demoMapper.MapBusinessToDto(_demoRepo.GetMyBusiness());
        }

        public IEnumerable<WorkItemDto> GetWorkItems() {
            var workItems = _demoRepo.GetWorkItems();
            var workItemDtos = new List<WorkItemDto>();

            foreach(var workItem in workItems)
            {
                workItemDtos.Add(_demoMapper.MapWorkItemToDto(workItem));
            }
            return workItemDtos;
        }
    }
}