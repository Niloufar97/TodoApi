using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Domain
{
    public enum TodoStatus
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2,
    }
    public class TodoItem:BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public  TodoStatus Status { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; } 
    }
}
