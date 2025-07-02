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

        public async Task<IEnumerable<TodoItemListDto>> TodoItemList() {
            var todos = await _todoRepository.GetAll();
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
    }
}
