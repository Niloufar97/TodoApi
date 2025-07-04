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
        //insert a todo item
        public async Task InsertAsync(TodoItem todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }
        
        // Update a todo item by ID
        
        public async Task Update(int id ,TodoItem todo)
        {
            var existingTodo = await _context.Todos.FindAsync(id);

            if (existingTodo == null) { 
                throw new KeyNotFoundException($"Todo with ID {id} not found.");
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.Status = todo.Status;
            existingTodo.UserId = todo.UserId;

            await _context.SaveChangesAsync();
        }
        // Delete a todo item by ID
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

        //get all todos
        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.Todos.ToListAsync(); ;
        }

        //get to do by Id
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
