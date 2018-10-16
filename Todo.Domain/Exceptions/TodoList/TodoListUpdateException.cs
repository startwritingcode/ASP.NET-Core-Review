using System;

namespace Todo.Domain.Exceptions.TodoList
{
    public class TodoListUpdateException : Exception
    {
        public TodoListUpdateException(string message) : base(message)
        {
        }
    }
}
