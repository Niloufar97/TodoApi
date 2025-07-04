using Todo.Core.Domain;

namespace Todo.Data.Repository
{
    public interface ITodoRepository
    {
        public Task InsertAsync(TodoItem todo);
        public Task Update(int id, TodoItem todo);
        public Task Delete(int todoId);
        public Task<IEnumerable<TodoItem>> GetAll();
        public Task<TodoItem> GetTodoById(int todoId);
    }
}
