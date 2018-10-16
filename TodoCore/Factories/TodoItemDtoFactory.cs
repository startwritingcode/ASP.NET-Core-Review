using Todo.Domain;
using TodoCore.Dtos;

namespace TodoCore.Factories
{
    public class TodoItemDtoFactory : ITodoItemDtoFactory
    {
        public TodoItemDto Create(TodoItem item)
        {
            return new TodoItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                IsComplete = item.IsComplete
            };
        }

        public TodoItem Create(TodoItemDto itemDto)
        {
            return new TodoItem
            {
                Id = itemDto.Id,
                Name = itemDto.Name,
                Description = itemDto.Description,
                IsComplete = itemDto.IsComplete
            };
        }
    }
}
