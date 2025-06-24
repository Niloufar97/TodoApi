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
    public class Todo:BaseEntity
    {
        string Title { get; set; }
        string Description { get; set; }
        TodoStatus Status { get; set; }

        int UserId { get; set; }
        User User { get; set; } 
    }
}
