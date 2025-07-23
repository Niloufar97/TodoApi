using Todo.Core.Domain;
using Todo.Data.Repository;
using Todo.Service.Dto;

namespace Todo.Service.Implementations
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository) {
            this._todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItemListDto>> TodoItemList(int userId) {
            var todos = await _todoRepository.GetUsersAllTodos(userId);
            var todosToReturn = todos.Select(Todo => new TodoItemListDto
            {
                Title = Todo.Title,
                Description = Todo.Description,
                Status = Todo.Status,
                StringCreatedAt = Todo.CreatedAt.ToLongDateString(),
                StringUpdatedAt = Todo.UpdatedAt.ToLongDateString()
            });
            return todosToReturn;
        }

        public async Task AddTodo(TodoItemRequestDto todoDto,int userId)
        {
            var newTodo = new TodoItem
            {
                Title = todoDto.Title,
                Description = todoDto.Description,
                Status = todoDto.Status,
                UserId = userId
            };
            await _todoRepository.InsertAsync(newTodo);
        }

        public async Task DeleteTodo(int todoId)
        {
            await _todoRepository.Delete(todoId);
        }

        public async Task<bool> UpdateTodo(int id, TodoItemRequestDto todoDto,int userId) {
            var existingTodo = await _todoRepository.GetTodoById(id);
            // Check if the todo item exists and belongs to the user
            if (existingTodo == null || existingTodo.UserId != userId)
                return false;

            existingTodo.Title = todoDto.Title;
            existingTodo.Description = todoDto.Description;
            existingTodo.Status = todoDto.Status;
            await _todoRepository.Update(id, existingTodo);
            return true;
        }
    }  
}
