using Invoicing.Contract;
using Invoicing.Contract.Dtos;

namespace Invoicing.Business
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IWorkItemRepository _workItemRepository;
        private readonly DemoDataDtoMapper _mapper;

        public WorkItemService(IWorkItemRepository workItemRepository, DemoDataDtoMapper mapper)
        {
            _workItemRepository = workItemRepository;
            _mapper = mapper;
        }

        public async Task<WorkItemDto?> GetByIdAsync(int id)
        {
            var workItem = await _workItemRepository.GetByIdAsync(id);
            if (workItem == null)
            {
                return null;
            }

            return _mapper.MapWorkItemToDto(workItem);
        }

        public async Task<IEnumerable<WorkItemDto>> GetAllAsync()
        {
            var workItems = await _workItemRepository.GetAllAsync();
            return workItems.Select(w => _mapper.MapWorkItemToDto(w)).ToList();
        }

        public async Task<WorkItemDto> CreateAsync(CreateWorkItemDto createDto)
        {
            var workItem = _mapper.MapCreateWorkItemDtoToWorkItem(createDto);
            var createdWorkItem = await _workItemRepository.CreateAsync(workItem);
            return _mapper.MapWorkItemToDto(createdWorkItem);
        }

        public async Task<WorkItemDto> UpdateAsync(int id, UpdateWorkItemDto updateDto)
        {
            var workItem = await _workItemRepository.GetByIdAsync(id);
            if (workItem == null)
            {
                throw new ArgumentException($"WorkItem with id {id} not found.", nameof(id));
            }

            _mapper.MapUpdateWorkItemDtoToWorkItem(updateDto, workItem);
            var updatedWorkItem = await _workItemRepository.UpdateAsync(workItem);
            return _mapper.MapWorkItemToDto(updatedWorkItem);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _workItemRepository.DeleteAsync(id);
        }
    }
}
