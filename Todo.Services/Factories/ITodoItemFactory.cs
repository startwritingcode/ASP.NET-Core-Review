using Todo.Domain;
using TodoCore.Data.Entities;

namespace Todo.Services.Factories
{
    public interface ITodoItemFactory
    {
        TodoItemEntity Create(TodoItem item);
        TodoItem Create(TodoItemEntity todoItemEntity);
    }
}