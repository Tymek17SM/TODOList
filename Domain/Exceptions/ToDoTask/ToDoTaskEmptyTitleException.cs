using Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ToDoTask
{
    internal sealed class ToDoTaskEmptyTitleException : ToDoTaskException
    {
        internal ToDoTaskEmptyTitleException() : base("Task cannot have an empty title.")
        {

        }
    }
}
