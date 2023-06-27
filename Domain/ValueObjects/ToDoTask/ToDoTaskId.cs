using Domain.Exceptions.ToDoTask;
using System;

namespace Domain.ValueObjects.ToDoTask
{
    public record ToDoTaskId
    {
        public Guid Value { get; }

        public ToDoTaskId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new ToDoTaskEmptyIdException();
            }

            Value = value;
        }

        //Jak robisz ToDoTaskGuid na Guid
        public static implicit operator Guid(ToDoTaskId id) => id.Value;
        

        //Jak robisz Guid na ToDoTaskId 
        public static implicit operator ToDoTaskId(Guid value) => new(value);
       
    }
}
