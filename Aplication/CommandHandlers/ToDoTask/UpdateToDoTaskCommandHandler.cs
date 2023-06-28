using Aplication.Commands.ToDoTask;
using Aplication.Exceptions.ToDoTask;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.CommandHandlers.ToDoTask
{
    internal class UpdateToDoTaskCommandHandler : IRequestHandler<UpdateToDoTaskCommand>
    {
        private readonly IToDoTaskRepository _repository;

        internal UpdateToDoTaskCommandHandler(IToDoTaskRepository repository)
        {
            _repository = repository;
        }

        async Task IRequestHandler<UpdateToDoTaskCommand>.Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var (id, title, description, deadline) = request;

            var toDoTask = await _repository.GetByIdAsynch(id);

            if (toDoTask == null)
            {
                throw new ToDoTaskNotFoundException();
            }

            toDoTask.UpdateTitle(title);
            toDoTask.UpdateDescription(description);
            toDoTask.UpdateDeadline(deadline);

            await _repository.UpdateAsynch(toDoTask);
        }
    }
}
