using System;
using System.Collections.Generic;
using Todo.Domain;

namespace Todo.Services
{
    public interface ITodoItemService
    {
        IEnumerable<TodoItem> Get();
        IEnumerable<TodoItem> Get(Func<TodoItem, bool> predicate);
        TodoItem Get(int id);
        TodoItem Add(TodoItem list);
        TodoItem Update(TodoItem list);
        void Delete(int todoItemId);
    }
}
