﻿using System;

namespace Todo.Domain.Exceptions.TodoItem
{
    public class TodoItemNotFoundException : Exception
    {
        public TodoItemNotFoundException(string message) : base(message)
        {
        }
    }
}
