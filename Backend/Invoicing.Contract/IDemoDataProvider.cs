using Invoicing.Contract.Dtos;

namespace Invoicing.Contract
{
    public interface IDemoDataProvider
    {
        public IEnumerable<CustomerDto> GetCustomers();
        public BusinessDto GetBusiness();
        public IEnumerable<WorkItemDto> GetWorkItems();
    }
}
