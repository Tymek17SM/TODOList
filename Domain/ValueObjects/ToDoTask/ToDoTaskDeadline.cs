using System;

namespace Domain.ValueObjects.ToDoTask
{
    public record ToDoTaskDeadline
    {
        public DateTime? Value { get; }

        public ToDoTaskDeadline(DateTime? value)
        {
            Value = value;
        }

       public static implicit operator DateTime?(ToDoTaskDeadline deadline) => deadline.Value;

       public static explicit operator ToDoTaskDeadline(DateTime? value) => new ToDoTaskDeadline(value);
    }
}
