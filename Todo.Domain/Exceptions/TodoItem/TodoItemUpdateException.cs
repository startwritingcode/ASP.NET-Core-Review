using System;

namespace Todo.Domain.Exceptions.TodoItem
{
    public class TodoItemUpdateException : Exception
    {
        public TodoItemUpdateException(string message) : base(message)
        {
        }
    }
}
