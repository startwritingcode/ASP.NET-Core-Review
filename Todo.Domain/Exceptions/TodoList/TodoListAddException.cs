using System;

namespace Todo.Domain.Exceptions.TodoList
{
    public class TodoListAddException : Exception
    {
        public TodoListAddException(string message) : base(message)
        {
        }
    }
}
