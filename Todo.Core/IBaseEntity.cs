using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core
{
    internal interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
