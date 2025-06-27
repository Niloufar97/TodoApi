using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Insert(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Update(TodoItem todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
        }
        public void Delete(int todoId)
        {
            var todo = _context.Todos.Find(todoId);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            else
            {
                //throw exception or log that the item was not found
            }
        }
        public IEnumerable<TodoItem> GetAll(int userId)
        {
            return _context.Todos
                .Where(t=> t.UserId == userId)
                .ToList();
        }
    }
}
