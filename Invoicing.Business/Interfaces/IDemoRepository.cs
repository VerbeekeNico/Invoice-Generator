using Invoicing.Domain.Entities;

namespace Invoicing.Business.Interfaces
{
    public interface IDemoRepository
    {
        public IEnumerable<Customer> GetCustomers();
        public Domain.Entities.Business GetMyBusiness();
        public IEnumerable<WorkItem> GetWorkItems();
    }
}
