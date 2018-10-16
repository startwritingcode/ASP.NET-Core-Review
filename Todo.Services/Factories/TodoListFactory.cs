using System.Linq;
using Todo.Domain;
using TodoCore.Data.Entities;

namespace Todo.Services.Factories
{
    public class TodoListFactory: ITodoListFactory
    {
        public TodoList Create(TodoListEntity todoListEntity)
        {
            return new TodoList
            {
                Id = todoListEntity.Id,
                Name = todoListEntity.Name,
                Description = todoListEntity.Description,
                Items = todoListEntity.Items.Select(i => new TodoItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    IsComplete = i.IsComplete
                })
            };
        }

        public TodoListEntity Create(TodoList list)
        {
            return new TodoListEntity
            {
                Id = list.Id,
                Name = list.Name,
                Description = list.Description,
                Items = list.Items.Select(i => new TodoItemEntity
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    IsComplete = i.IsComplete,
                    TodoListId = list.Id
                }).ToList()
            };
        }
    }
}
