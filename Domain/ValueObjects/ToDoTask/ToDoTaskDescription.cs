using System;

namespace Domain.ValueObjects.ToDoTask
{
    public record ToDoTaskDescription
    {
        public string Value { get; }

        public ToDoTaskDescription(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                Value = "";
            }

            Value = value;
        }

        public static implicit operator string(ToDoTaskDescription description) => description.Value;

        public static explicit operator ToDoTaskDescription(string value) => new(value);
    }
}
