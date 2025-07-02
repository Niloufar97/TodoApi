using Microsoft.AspNetCore.Mvc;
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

    }
}
