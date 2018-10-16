using System.Collections.Generic;
using System.Linq;
using Todo.Domain;
using TodoCore.Data.Entities;

namespace Todo.Services.Factories
{
    public class TodoListFactory: ITodoListFactory
    {
        public TodoList Create(TodoListEntity todoListEntity)
        {
            var list = new TodoList
            {
                Id = todoListEntity.Id,
                Name = todoListEntity.Name,
                Description = todoListEntity.Description,
                Items = new List<TodoItem>()
            };

            if(todoListEntity.Items != null)
            {
                list.Items = todoListEntity.Items.Select(i => new TodoItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    IsComplete = i.IsComplete
                });
            }

            return list;
        }

        public TodoListEntity Create(TodoList list)
        {
            var entity =  new TodoListEntity
            {
                Id = list.Id,
                Name = list.Name,
                Description = list.Description,
                Items = new List<TodoItemEntity>()
            };

            if(list.Items != null)
            {
                entity.Items = list.Items.Select(i => new TodoItemEntity
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    IsComplete = i.IsComplete,
                    TodoListId = list.Id
                }).ToList();
            }

            return entity;
        }
    }
}
