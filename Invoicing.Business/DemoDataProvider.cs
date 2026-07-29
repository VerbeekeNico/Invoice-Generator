using Invoicing.Business.Interfaces;
using Invoicing.Contract;
using Invoicing.Contract.Dtos;

namespace Invoicing.Business
{
    public class DemoDataProvider : IDemoDataProvider
    {
        private IDemoRepository _demoRepo;
        private DemoDataDtoMapper _demoMapper;
        public DemoDataProvider(IDemoRepository demoRepository, DemoDataDtoMapper demoMapper) {
            _demoRepo = demoRepository;
            _demoMapper = demoMapper;
         }

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