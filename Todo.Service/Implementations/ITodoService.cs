using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Service.Dto;

namespace Todo.Service.Implementations
{
    public interface ITodoService
    {
        Task AddTodo(TodoItemRequestDto todoDto, int userId);
        Task DeleteTodo(int todoId);
        Task<IEnumerable<TodoItemListDto>> TodoItemList(int userId);
        Task<bool> UpdateTodo(int id, TodoItemRequestDto todoDto,int userId);
    }
}
