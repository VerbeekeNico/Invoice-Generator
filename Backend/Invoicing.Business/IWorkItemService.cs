using Invoicing.Contract.Dtos;

namespace Invoicing.Business
{
    public interface IWorkItemService
    {
        Task<WorkItemDto?> GetByIdAsync(int id);
        Task<IEnumerable<WorkItemDto>> GetAllAsync();
        Task<WorkItemDto> CreateAsync(CreateWorkItemDto createDto);
        Task<WorkItemDto> UpdateAsync(int id, UpdateWorkItemDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
