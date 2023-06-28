using Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Exceptions.ToDoTask
{
    internal class ToDoTaskNotFoundException : ToDoTaskException
    {
        public ToDoTaskNotFoundException() : base("Task not found.")
        {

        }
    }
}
