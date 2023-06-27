using Domain.ValueObjects.ToDoTask;
using Shared.Abstraction.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class ToDoTask : AuditableEntity
    {
        public ToDoTaskId Id { get; private set; }

        private ToDoTaskTitle _title;

        private ToDoTaskDescription _description;

        private ToDoTaskDeadline _deadline;

        private ToDoTask()
        {

        }

        internal ToDoTask(ToDoTaskId id, ToDoTaskTitle title, ToDoTaskDescription description, 
            ToDoTaskDeadline deadline)
        {
            Id = id;
            _title = title;
            _description = description; 
            _deadline = deadline;
        }

        public void UpdateTitle(ToDoTaskTitle title)
        {
            this._title = title;
        }

        public void UpdateDescription(ToDoTaskDescription description) 
        {
            this._description = description;
        }

        public void UpdateDeadline(ToDoTaskDeadline deadline) 
        {
            this._deadline = deadline;
        }
    }
}
