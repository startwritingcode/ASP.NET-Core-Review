using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain;
using Todo.Domain.Exceptions.TodoItem;
using Todo.Repositories;
using Todo.Services.Factories;
using TodoCore.Data.Entities;

namespace Todo.Services.Tests
{
    [TestFixture]
    public class TodoItemServiceTests
    {
        private MockRepository _mockRepository;
        private Mock<ITodoItemRepository> _todoItemRepository;
        private ITodoItemFactory _todoItemFactory;

        private ITodoItemService _todoItemService;

        TodoItem _newTodoItem;
        TodoItemEntity _newTodoItemEntity;

        TodoItem _existingTodoItem;
        TodoItemEntity _existingTodoItemEntity;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            _todoItemRepository = _mockRepository.Create<ITodoItemRepository>();

            _todoItemFactory = new TodoItemFactory();

            _todoItemService = new TodoItemService(_todoItemRepository.Object, _todoItemFactory);

            _newTodoItem = new TodoItem
            {
                Name = "Test Item",
                Description = "This is just a test item"
            };

            _newTodoItemEntity = new TodoItemEntity
            {
                Id = 1,
                Name = "Test Item",
                Description = "This is just a test item"
            };

            _existingTodoItem = new TodoItem
            {
                Id = 5,
                Name = "Existing Test Item",
                Description = "This is just an existing test item"
            };

            _existingTodoItemEntity = new TodoItemEntity
            {
                Id = 5,
                Name = "Existing Test Item",
                Description = "This is just an existing test item"
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
            _todoItemRepository.Setup(r => r.Add(It.Is<TodoItemEntity>(e => e.Id == 0))).Returns(_newTodoItemEntity);

            var result = _todoItemService.Add(_newTodoItem);

            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void Add_RepositoryThrowsException_ThrowsTodoItemAddException()
        {
            _todoItemRepository.Setup(r => r.Add(It.IsAny<TodoItemEntity>())).Throws<Exception>();

            Assert.Throws<TodoItemAddException>(() => _todoItemService.Add(_newTodoItem));
        }

        [Test]
        public void Delete_HappyPath()
        {
            _todoItemRepository.Setup(r => r.Delete(5));

            _todoItemService.Delete(5);
        }

        [Test]
        public void Delete_RepositoryThrowsException_ThrowsTodoItemDeleteException()
        {
            _todoItemRepository.Setup(r => r.Delete(5)).Throws<Exception>();

            Assert.Throws<TodoItemDeleteException>(() => _todoItemService.Delete(5));
        }

        [Test]
        public void Get_All_HappyPath()
        {
            _todoItemRepository.Setup(r => r.Get()).Returns(new List<TodoItemEntity> { _existingTodoItemEntity });

            var result = _todoItemService.Get();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(5, result.First().Id);
        }

        [Test]
        public void Get_WithFilter_FiltersProperly()
        {
            _todoItemRepository.Setup(r => r.Get()).Returns(new List<TodoItemEntity> { _newTodoItemEntity, _existingTodoItemEntity });

            var result = _todoItemService.Get(s => s.Id == 5);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(5, result.First().Id);
        }

        [Test]
        public void Get_SingleItem_HappyPath()
        {
            _todoItemRepository.Setup(r => r.Get(5)).Returns(_existingTodoItemEntity);

            var result = _todoItemService.Get(5);

            Assert.AreEqual(5, result.Id);
        }

        [Test]
        public void Get_RepositoryReturnsNull_ThrowsTodoItemNotFoundException()
        {
            _todoItemRepository.Setup(r => r.Get(3)).Returns((TodoItemEntity)null);

            Assert.Throws<TodoItemNotFoundException>(() => _todoItemService.Get(3));
        }

        [Test]
        public void Update_HappyPath()
        {
            _todoItemRepository.Setup(r => r.Update(It.Is<TodoItemEntity>(e => e.Id == 5))).Returns(_existingTodoItemEntity);

            var result = _todoItemService.Update(_existingTodoItem);

            Assert.AreEqual(5, result.Id);
        }

        [Test]
        public void Update_RepositoryThrowsException_ThrowsTodoItemUpdateException()
        {
            _todoItemRepository.Setup(r => r.Update(It.Is<TodoItemEntity>(e => e.Id == 5))).Throws<Exception>();

            Assert.Throws<TodoItemUpdateException>(() => _todoItemService.Update(_existingTodoItem));
        }
    }
}
