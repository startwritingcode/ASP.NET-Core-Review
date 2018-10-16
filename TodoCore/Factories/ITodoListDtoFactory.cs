using Todo.Domain;
using TodoCore.Dtos;

namespace TodoCore.Factories
{
    public interface ITodoListDtoFactory
    {
        TodoListDto Create(TodoList list);
        TodoList Create(TodoListDto listDto);
    }
}
