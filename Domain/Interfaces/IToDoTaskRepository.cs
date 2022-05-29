using Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IToDoTaskRepository
    {
        Task<IEnumerable<ToDoTask>> GetAllAsynch(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        Task<int> GetAllCountAsynch(string filterBy);
        Task<ToDoTask> GetByIdAsynch(int id);
        Task<ToDoTask> AddAsynch(ToDoTask task);
        Task UpdateAsynch(ToDoTask task);
        Task DeleteAsynch(ToDoTask task);
    }
}
