using Todo.Core.Domain;

namespace Todo.Data.Repository
{
    public interface ITodoRepository
    {
        public void Insert(TodoItem todo);
        public void Update(TodoItem todo);
        public void Delete(int todoId);
        public IEnumerable<TodoItem> GetAll(int userId);

    }
}
