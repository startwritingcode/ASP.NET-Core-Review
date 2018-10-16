using System.Linq;
using Todo.Domain;
using TodoCore.Dtos;

namespace TodoCore.Factories
{
    public class TodoListDtoFactory : ITodoListDtoFactory
    {
        public TodoListDto Create(TodoList list)
        {
            return new TodoListDto
            {
                Id = list.Id,
                Name = list.Name,
                Description = list.Description,
                Items = list.Items.Select(i => new TodoItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    IsComplete = i.IsComplete
                }).ToList()
            };
        }

        public TodoList Create(TodoListDto listDto)
        {
            return new TodoList
            {
                Id = listDto.Id,
                Name = listDto.Name,
                Description = listDto.Description,
                Items = listDto.Items.Select(i => new TodoItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    IsComplete = i.IsComplete
                }).ToList()
            };
        }
    }
}
