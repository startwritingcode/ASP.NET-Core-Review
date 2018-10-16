using System;

namespace Todo.Domain.Exceptions.TodoItem
{
    public class TodoItemAddException : Exception
    {
        public TodoItemAddException(string message) : base(message)
        {
        }
    }
}
