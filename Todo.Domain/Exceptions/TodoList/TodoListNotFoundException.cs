using System;

namespace Todo.Domain.Exceptions.TodoList
{
    public class TodoListNotFoundException: Exception
    {
        public TodoListNotFoundException(string message) : base(message)
        {
        }
    }
}
