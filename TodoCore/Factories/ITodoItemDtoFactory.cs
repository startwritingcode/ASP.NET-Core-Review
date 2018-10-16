using Todo.Domain;
using TodoCore.Dtos;

namespace TodoCore.Factories
{
    public interface ITodoItemDtoFactory
    {
        TodoItemDto Create(TodoItem item);
        TodoItem Create(TodoItemDto itemDto);
    }
}
