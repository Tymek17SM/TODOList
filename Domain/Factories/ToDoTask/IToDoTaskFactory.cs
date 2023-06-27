using Domain.Entities;
using Domain.ValueObjects.ToDoTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.ToDoTask
{
    public interface IToDoTaskFactory
    {
        Entities.ToDoTask Create(ToDoTaskTitle title, ToDoTaskDescription description, ToDoTaskDeadline deadline);
    }
}
