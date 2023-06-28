using Aplication.Dto.ToDoTask;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Queries.ToDoTask
{
    internal record ToDoTaskGetAllQuery(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        : IRequest<IEnumerable<ToDoTaskDto>>
    {
    }
}
