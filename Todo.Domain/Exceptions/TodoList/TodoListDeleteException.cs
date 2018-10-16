using System;

namespace Todo.Domain.Exceptions.TodoList
{
    public class TodoListDeleteException : Exception
    {
        public TodoListDeleteException(string message) : base(message)
        {
        }
    }
}
