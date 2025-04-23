using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskify.Application.DTOs;
using Taskify.Application.Interfaces;
using Taskify.Domain;

namespace Taskify.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll()
        {
            var tasks = await _service.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(Guid id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskDto dto)
        {
            var task = await _service.CreateTaskAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteTaskAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
