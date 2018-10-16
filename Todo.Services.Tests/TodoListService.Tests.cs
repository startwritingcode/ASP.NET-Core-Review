using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain;
using Todo.Domain.Exceptions.TodoList;
using Todo.Repositories;
using Todo.Services.Factories;
using TodoCore.Data.Entities;

namespace Todo.Services.Tests
{
    [TestFixture]
    public class TodoListServiceTests
    {
        private MockRepository _mockRepository;
        private Mock<ITodoListRepository> _todoListRepository;
        private ITodoListFactory _todoListFactory;

        private ITodoListService _todoListService;

        private TodoList _newTodoList;
        private TodoListEntity _newTodoListEntity;

        private TodoList _existingTodoList;
        private TodoListEntity _existingTodoListEntity;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            _todoListRepository = _mockRepository.Create<ITodoListRepository>();
            _todoListFactory = new TodoListFactory();

            _todoListService = new TodoListService(_todoListRepository.Object, _todoListFactory);

            _newTodoList = new TodoList
            {
                Name = "New Todo List",
                Description = "This is a new Todo List",
                Items = new List<TodoItem>()
            };

            _newTodoListEntity = new TodoListEntity
            {
                Id = 1,
                Name = "New Todo List",
                Description = "This is a new Todo List",
                Items = new List<TodoItemEntity>()
            };

            _existingTodoList = new TodoList
            {
                Id = 5,
                Name = "Existing Todo List",
                Description = "This is an existing Todo List",
                Items = new List<TodoItem>()
            };

            _existingTodoListEntity = new TodoListEntity
            {
                Id = 5,
                Name = "Existing Todo List",
                Description = "This is an existing Todo List",
                Items = new List<TodoItemEntity>()
            };
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void Add_HappyPath()
        {
            _todoListRepository.Setup(r => r.Add(It.Is<TodoListEntity>(e => e.Id == 0))).Returns(_newTodoListEntity);

            var result = _todoListService.Add(_newTodoList);

            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void Add_RepositoryThrowsException_ThrowsTodoListAddException()
        {
            _todoListRepository.Setup(r => r.Add(It.IsAny<TodoListEntity>())).Throws<Exception>();

            Assert.Throws<TodoListAddException>(() => _todoListService.Add(_newTodoList));
        }

        [Test]
        public void Delete_HappyPath()
        {
            _todoListRepository.Setup(r => r.Delete(5));

            _todoListService.Delete(5);
        }

        [Test]
        public void Delete_RepositoryThrowsException_ThrowsTodoListDeleteException()
        {
            _todoListRepository.Setup(r => r.Delete(5)).Throws<Exception>();

            Assert.Throws<TodoListDeleteException>(() => _todoListService.Delete(5));
        }

        [Test]
        public void Get_All_HappyPath()
        {
            _todoListRepository.Setup(r => r.Get()).Returns(new List<TodoListEntity> { _existingTodoListEntity });

            var result = _todoListService.Get();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(5, result.First().Id);
        }

        [Test]
        public void Get_WithFilter_FiltersProperly()
        {
            _todoListRepository.Setup(r => r.Get()).Returns(new List<TodoListEntity> { _newTodoListEntity, _existingTodoListEntity });

            var result = _todoListService.Get(s => s.Id == 5);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(5, result.First().Id);
        }

        [Test]
        public void Get_SingleList_HappyPath()
        {
            _todoListRepository.Setup(r => r.Get(5)).Returns(_existingTodoListEntity);

            var result = _todoListService.Get(5);

            Assert.AreEqual(5, result.Id);
        }

        [Test]
        public void Get_RepositoryReturnsNull_ThrowsTodoListNotFoundException()
        {
            _todoListRepository.Setup(r => r.Get(3)).Returns((TodoListEntity)null);

            Assert.Throws<TodoListNotFoundException>(() => _todoListService.Get(3));
        }

        [Test]
        public void Update_HappyPath()
        {
            _todoListRepository.Setup(r => r.Update(It.Is<TodoListEntity>(e => e.Id == 5))).Returns(_existingTodoListEntity);

            var result = _todoListService.Update(_existingTodoList);

            Assert.AreEqual(5, result.Id);
        }

        [Test]
        public void Update_RepositoryThrowsException_ThrowsTodoListUpdateException()
        {
            _todoListRepository.Setup(r => r.Update(It.Is<TodoListEntity>(e => e.Id == 5))).Throws<Exception>();

            Assert.Throws<TodoListUpdateException>(() => _todoListService.Update(_existingTodoList));
        }
    }
}
