using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain;
using Todo.Domain.Exceptions.TodoItem;
using Todo.Repositories;
using Todo.Services.Factories;
using TodoCore.Data.Entities;

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

            TodoItemEntity entity;
            try
            {
                entity = _todoItemRepository.Add(itemEnity);
            }catch(Exception ex)
            {
                throw new TodoItemAddException(ex.Message);
            }

            return _todoItemFactory.Create(entity);
        }

        public void Delete(int todoItemId)
        {
            try
            {
                _todoItemRepository.Delete(todoItemId);
            }catch(Exception ex)
            {
                throw new TodoItemDeleteException(ex.Message);
            }
            
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

            TodoItemEntity updatedEntity;
            try
            {
                updatedEntity = _todoItemRepository.Update(entity);
            }catch(Exception ex)
            {
                throw new TodoItemUpdateException(ex.Message);
            }
            

            return _todoItemFactory.Create(updatedEntity);
        }
    }
}
