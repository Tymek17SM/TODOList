using Aplication.Dto;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Attributes;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IToDoTaskService _taskService;

        public TaskController(IToDoTaskService taskService)
        {
            _taskService = taskService;
        }

        [SwaggerOperation(Summary ="Get sort fields")]
        [HttpGet("[action]")]
        public IActionResult GetSortFields()
        {
            return Ok(SortingHelper.GetSortFields().Select(s => s.Key));
        }

        [SwaggerOperation(Summary ="Get all tasks")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy="")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var totalRecords = await _taskService.GetAllCountAsynch(filterBy);

            var tasks = await _taskService.GetAllAsynch(validPaginationFilter.PageNumber, validPaginationFilter.PageSize, 
                validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);

            return Ok(PaginationHelper.CreatePageResponse<ToDoTaskDto>(tasks, validPaginationFilter, totalRecords));
        }

        [SwaggerOperation(Summary ="Get a specific task by unique id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var task = await _taskService.GetByIdAsynch(id);

            return Ok(new Response<ToDoTaskDto>(task));
        }

        [ValidateFilter]
        [SwaggerOperation(Summary ="Create a new task")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoTaskDto taskDto)
        {
            var newTask = await _taskService.AddAsynch(taskDto);

            return Created($"api/Task/{newTask.Id}", new Response<ToDoTaskDto>(newTask));
        }

        [ValidateFilter]
        [SwaggerOperation(Summary ="Update a existing task")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoTaskDto taskDto)
        {
            await _taskService.UpdateAsynch(taskDto);

            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific task")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteAsynch(id);

            return NoContent();
        }
    }
}
