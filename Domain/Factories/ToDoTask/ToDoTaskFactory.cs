using Domain.ValueObjects.ToDoTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.ToDoTask
{
    public sealed class ToDoTaskFactory : IToDoTaskFactory
    {
        Entities.ToDoTask IToDoTaskFactory.Create(ToDoTaskTitle title, ToDoTaskDescription description, ToDoTaskDeadline deadline)
        {
            throw new NotImplementedException();
        }
    }
}
