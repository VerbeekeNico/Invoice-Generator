using Invoicing.Business;
using Invoicing.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IncogNicoInvoicing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkItemsController : ControllerBase
    {
        private readonly IWorkItemService _workItemService;

        public WorkItemsController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        /// <summary>
        /// Create a new WorkItem
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<WorkItemDto>> Create([FromBody] CreateWorkItemDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workItemDto = await _workItemService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = workItemDto.Id }, workItemDto);
        }

        /// <summary>
        /// Get WorkItem by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkItemDto>> GetById(int id)
        {
            var workItemDto = await _workItemService.GetByIdAsync(id);
            if (workItemDto == null)
            {
                return NotFound(new { message = $"WorkItem with id {id} not found." });
            }

            return Ok(workItemDto);
        }

        /// <summary>
        /// Get all WorkItems
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkItemDto>>> GetAll()
        {
            var workItems = await _workItemService.GetAllAsync();
            return Ok(workItems);
        }

        /// <summary>
        /// Update an existing WorkItem
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<WorkItemDto>> Update(int id, [FromBody] UpdateWorkItemDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var workItemDto = await _workItemService.UpdateAsync(id, updateDto);
                return Ok(workItemDto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a WorkItem
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _workItemService.DeleteAsync(id);
                if (!success)
                {
                    return NotFound(new { message = $"WorkItem with id {id} not found." });
                }

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
