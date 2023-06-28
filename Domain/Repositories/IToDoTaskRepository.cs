using Domain.Entities;
using Domain.ValueObjects.ToDoTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IToDoTaskRepository
    {
        Task<ToDoTask> GetByIdAsynch(ToDoTaskId id);
        Task<ToDoTask> AddAsynch(ToDoTask task);
        Task UpdateAsynch(ToDoTask task);
        Task DeleteAsynch(ToDoTask task);
    }
}
