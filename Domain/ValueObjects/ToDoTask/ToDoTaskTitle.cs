using Domain.Exceptions.ToDoTask;
using System;

namespace Domain.ValueObjects.ToDoTask
{
    public record ToDoTaskTitle
    {
        public string Value { get; }

        public ToDoTaskTitle(string value)
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ToDoTaskEmptyTitleException();
            }

            Value = value;
        }

        public static implicit operator string(ToDoTaskTitle title) => title.Value;

        public static implicit operator ToDoTaskTitle(string value) => new(value);
    }
}
