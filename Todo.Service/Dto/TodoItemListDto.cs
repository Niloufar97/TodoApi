using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;

namespace Todo.Service.Dto
{
    public class TodoItemListDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TodoStatus Status { get; set; }
        public string? StringCreatedAt { get; set; }
        public string? StringUpdatedAt { get; set; }

    }
}
