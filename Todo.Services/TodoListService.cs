using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain;
using Todo.Domain.Exceptions.TodoList;
using Todo.Repositories;
using Todo.Services.Factories;

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
            var entity = _todoListRepository.Add(listEnity);

            return _todoListFactory.Create(entity);
        }

        public void Delete(int todoListId)
        {
            _todoListRepository.Delete(todoListId);
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
            var updateEntity = _todoListRepository.Update(entity);

            return _todoListFactory.Create(updateEntity);
        }
    }
}
