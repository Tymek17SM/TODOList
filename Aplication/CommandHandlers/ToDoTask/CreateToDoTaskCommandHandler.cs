using Aplication.Commands.ToDoTask;
using Aplication.Interfaces;
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
    internal sealed class CreateToDoTaskCommandHandler : IRequestHandler<CreateToDoTaskCommand>
    {
        private readonly IToDoTaskRepository _repository;
        private readonly IToDoTaskFactory _factory;

        internal CreateToDoTaskCommandHandler(IToDoTaskRepository repository, IToDoTaskFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        async Task IRequestHandler<CreateToDoTaskCommand>.Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var (title, description, deadline) = request;

            var newToDoTask = _factory.Create(title, description, deadline);

            await _repository.AddAsynch(newToDoTask);
        }
    }
}
