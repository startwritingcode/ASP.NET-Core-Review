using Todo.Domain;
using TodoCore.Data.Entities;

namespace Todo.Services.Factories
{
    public class TodoItemFactory : ITodoItemFactory
    {
        public TodoItem Create(TodoItemEntity todoItemEntity)
        {
            return new TodoItem
            {
                Id = todoItemEntity.Id,
                Name = todoItemEntity.Name,
                Description = todoItemEntity.Description,
                IsComplete = todoItemEntity.IsComplete
            };
        }

        public TodoItemEntity Create(TodoItem item)
        {
            return new TodoItemEntity
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                IsComplete = item.IsComplete
            };
        }
    }
}
