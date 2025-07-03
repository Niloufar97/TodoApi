using Microsoft.AspNetCore.Mvc;
using Todo.Service.Dto;
using Todo.Service.Implementations;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            this._todoService = todoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTodos() {
            var allTodos = await _todoService.TodoItemList();
            return Ok(allTodos);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTodo([FromBody] TodoItemRequestDto todoItemRequestDto)
        {
            if (todoItemRequestDto == null)
            {
                return BadRequest();
            }
            await _todoService.AddTodo(todoItemRequestDto);
            return Created();
        }

        [HttpDelete("{todoId}")]
        public async Task<IActionResult> DeleteTood(int todoId)
        {
            await _todoService.DeleteTodo(todoId);
            return NoContent();
        }

    }
}
