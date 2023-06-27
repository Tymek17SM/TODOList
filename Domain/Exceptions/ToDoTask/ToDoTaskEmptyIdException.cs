using Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ToDoTask
{
    internal sealed class ToDoTaskEmptyIdException : ToDoTaskException
    {
        internal ToDoTaskEmptyIdException() : base("Task cannot have an empty Id!")
        {

        }
    }
}
