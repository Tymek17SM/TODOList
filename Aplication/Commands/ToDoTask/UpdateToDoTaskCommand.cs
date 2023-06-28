﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Commands.ToDoTask
{
    public record UpdateToDoTaskCommand(Guid id, string taskTitle, string taskDescription, DateTime deadline) : IRequest
    {
    }
}
