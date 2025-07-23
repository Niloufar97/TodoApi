using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;

namespace Todo.Service.Dto
{
    public class TodoItemRequestDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required TodoStatus Status { get; set; }
    }
}
