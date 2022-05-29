using Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IToDoTaskService
    {
        Task<IEnumerable<ToDoTaskDto>> GetAllAsynch(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        Task<int> GetAllCountAsynch(string filterBy);
        Task<ToDoTaskDto> GetByIdAsynch(int id);
        Task<ToDoTaskDto> AddAsynch(CreateToDoTaskDto taskDto);
        Task UpdateAsynch(UpdateToDoTaskDto taskDto);
        Task DeleteAsynch(int id);
    }
}
