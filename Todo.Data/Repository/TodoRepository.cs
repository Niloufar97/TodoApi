using Microsoft.EntityFrameworkCore;
using Todo.Core.Domain;

namespace Todo.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;
        public TodoRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task InsertAsync(TodoItem todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public void Update(TodoItem todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
        }
        public async Task Delete(int todoId)
        {
            var todo = await _context.Todos.FindAsync(todoId);
            if (todo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {todoId} not found.");
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.Todos.ToListAsync(); ;
        }

        public async Task<TodoItem> GetTodoById(int todoId)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == todoId);
            if(todo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {todoId} not found.");
            }
            return todo;
        }
    }
}
