using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.Service.Dto;
using Todo.Service.Implementations;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        this._todoService = todoService;
    }
    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var allTodos = await _todoService.TodoItemList(userId);
        return Ok(allTodos);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewTodo([FromBody] TodoItemRequestDto todoItemRequestDto)
    {
        if (todoItemRequestDto == null)
        {
            return BadRequest();
        }
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await _todoService.AddTodo(todoItemRequestDto, userId);
        return Created();
    }

    [HttpDelete("{todoId}")]
    public async Task<IActionResult> DeleteTood(int todoId)
    {
        await _todoService.DeleteTodo(todoId);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoItemRequestDto todoItemRequestDto)
    {
        if (todoItemRequestDto == null)
        {
            return BadRequest();
        }
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var success = await _todoService.UpdateTodo(id, todoItemRequestDto, userId);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();

    }
}
