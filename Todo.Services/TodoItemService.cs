using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain;
using Todo.Domain.Exceptions;
using Todo.Repositories;
using Todo.Services.Factories;

namespace Todo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly ITodoItemFactory _todoItemFactory;

        public TodoItemService(ITodoItemRepository todoItemRepository, ITodoItemFactory todoItemFactory)
        {
            _todoItemRepository = todoItemRepository;
            _todoItemFactory = todoItemFactory;
        }

        public TodoItem Add(TodoItem item)
        {
            var itemEnity = _todoItemFactory.Create(item);
            var entity = _todoItemRepository.Add(itemEnity);

            return _todoItemFactory.Create(entity);
        }

        public void Delete(int todoItemId)
        {
            _todoItemRepository.Delete(todoItemId);
        }

        public IEnumerable<TodoItem> Get()
        {
            var items = _todoItemRepository.Get();

            return items.Select(_todoItemFactory.Create);
        }

        public IEnumerable<TodoItem> Get(Func<TodoItem, bool> predicate)
        {
            var entities = _todoItemRepository.Get();
            var items = entities.Select(_todoItemFactory.Create).ToList();

            return items.Where(predicate);
        }

        public TodoItem Get(int id)
        {
            var entity = _todoItemRepository.Get(id);
            if (entity == null)
            {
                throw new TodoItemNotFoundException($"Couldn't find item with id: {id}");
            }

            return _todoItemFactory.Create(entity);
        }

        public TodoItem Update(TodoItem item)
        {
            var entity = _todoItemFactory.Create(item);
            var updateEntity = _todoItemRepository.Update(entity);

            return _todoItemFactory.Create(updateEntity);
        }
    }
}
