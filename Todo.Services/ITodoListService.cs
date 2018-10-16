using System;
using System.Collections.Generic;
using Todo.Domain;

namespace Todo.Services
{
    public interface ITodoListService
    {
        IEnumerable<TodoList> Get();
        IEnumerable<TodoList> Get(Func<TodoList, bool> predicate);
        TodoList Get(int id);
        TodoList Add(TodoList list);
        TodoList Update(TodoList list);
        void Delete(int todoListId);
    }
}
