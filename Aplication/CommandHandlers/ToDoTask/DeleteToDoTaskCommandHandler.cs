using Aplication.Commands.ToDoTask;
using Aplication.Exceptions.ToDoTask;
using Domain.Factories.ToDoTask;
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
    internal class DeleteToDoTaskCommandHandler : IRequestHandler<DeleteToDoTaskCommand>
    {
        private readonly IToDoTaskRepository _repository;

        internal DeleteToDoTaskCommandHandler(IToDoTaskRepository repository)
        {
            _repository = repository;
        }

        async Task IRequestHandler<DeleteToDoTaskCommand>.Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var toDoTask = await _repository.GetByIdAsynch(request.id);

            if (toDoTask == null)
            {
                throw new ToDoTaskNotFoundException();
            }

            await _repository.DeleteAsynch(toDoTask);
        }
    }
}
