using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp_Back.API.Filters;
using TodoApp_Back.Application.Commands;
using TodoApp_Back.Application.Queries;
using TodoApp_Back.Domain.Entities;

namespace TodoApp_Back.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeHmac]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllTasksQuery());
            if (response == null)
            {
                return NotFound();
            }
            else if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        [AuthorizeHmac]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetTaskByIdQuery(id));
            if (response == null)
            {
                return NotFound();
            }
            else if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeHmac]
        public async Task<IActionResult> Create(TaskEntity task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(new CreateTaskCommand(task));
            TaskEntity taskEntity = response.Result as TaskEntity;
            return CreatedAtAction(nameof(GetById), new { id = taskEntity.Id }, taskEntity);
        }

        [HttpPut]
        [AuthorizeHmac]
        public async Task<IActionResult> Update(TaskEntity task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (task.Id != task.Id)
            {
                return BadRequest("Task ID mismatch");
            }

            var response = await _mediator.Send(new UpdateTaskCommand(task));
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [AuthorizeHmac]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteTaskCommand(id));
            if (response == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
