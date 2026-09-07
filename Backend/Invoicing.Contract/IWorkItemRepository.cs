using Invoicing.Domain.Entities;

namespace Invoicing.Contract
{
    public interface IWorkItemRepository
    {
        Task<WorkItem?> GetByIdAsync(int id);
        Task<IEnumerable<WorkItem>> GetAllAsync();
        Task<WorkItem> CreateAsync(WorkItem workItem);
        Task<WorkItem> UpdateAsync(WorkItem workItem);
        Task<bool> DeleteAsync(int id);
    }
}
