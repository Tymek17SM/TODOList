using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
    internal interface IToDoTaskService
    {
        Task<int> GetAllCountAsynch(string filterBy);
    }
}
