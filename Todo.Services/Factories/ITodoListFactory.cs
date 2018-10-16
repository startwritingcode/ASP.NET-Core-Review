using Todo.Domain;
using TodoCore.Data.Entities;

namespace Todo.Services.Factories
{
    public interface ITodoListFactory
    {
        TodoList Create(TodoListEntity todoListEntity);
        TodoListEntity Create(TodoList list);
    }
}
