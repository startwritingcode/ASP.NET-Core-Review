using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain;
using Todo.Domain.Exceptions.TodoList;
using Todo.Repositories;
using Todo.Services.Factories;
using TodoCore.Data.Entities;

namespace Todo.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;
        private readonly ITodoListFactory _todoListFactory;

        public TodoListService(ITodoListRepository todoListRepository, ITodoListFactory todoListFactory)
        {
            _todoListRepository = todoListRepository;
            _todoListFactory = todoListFactory;
        }

        public TodoList Add(TodoList list)
        {
            var listEnity = _todoListFactory.Create(list);

            TodoListEntity entity;
            try
            {
                entity = _todoListRepository.Add(listEnity);
            }catch(Exception ex)
            {
                throw new TodoListAddException(ex.Message);
            }

            return _todoListFactory.Create(entity);
        }

        public void Delete(int todoListId)
        {
            try
            {
                _todoListRepository.Delete(todoListId);
            }catch(Exception ex)
            {
                throw new TodoListDeleteException(ex.Message);
            }
            
        }

        public IEnumerable<TodoList> Get()
        {
            var lists = _todoListRepository.Get();

            return lists.Select(_todoListFactory.Create);
        }

        public IEnumerable<TodoList> Get(Func<TodoList, bool> predicate)
        {
            var entities = _todoListRepository.Get();
            var lists = entities.Select(_todoListFactory.Create).ToList();

            return lists.Where(predicate);
        }

        public TodoList Get(int id)
        {
            var entity = _todoListRepository.Get(id);
            if(entity == null)
            {
                throw new TodoListNotFoundException($"Couldn't find list with id: {id}");
            }

            return _todoListFactory.Create(entity);
        }

        public TodoList Update(TodoList list)
        {
            var entity = _todoListFactory.Create(list);

            TodoListEntity updatedEntity;
            try
            {
                updatedEntity = _todoListRepository.Update(entity);
            }catch(Exception ex)
            {
                throw new TodoListUpdateException(ex.Message);
            }

            return _todoListFactory.Create(updatedEntity);
        }
    }
}
