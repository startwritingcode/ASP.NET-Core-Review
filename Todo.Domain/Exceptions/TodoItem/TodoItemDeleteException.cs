using System;

namespace Todo.Domain.Exceptions.TodoItem
{
    public class TodoItemDeleteException : Exception
    {
        public TodoItemDeleteException(string message) : base(message)
        {
        }
    }
}
