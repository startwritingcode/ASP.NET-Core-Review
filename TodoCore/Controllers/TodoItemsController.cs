using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Domain.Exceptions.TodoItem;
using Todo.Domain.Exceptions.TodoList;
using Todo.Services;
using TodoCore.Dtos;
using TodoCore.Factories;

namespace TodoCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        private readonly ITodoItemDtoFactory _todoItemDtoFactory;

        public TodoItemsController(ITodoItemService todoItemService, ITodoItemDtoFactory todoItemDtoFactory)
        {
            _todoItemService = todoItemService;
            _todoItemDtoFactory = todoItemDtoFactory;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoItemDto>), 200)]
        public IActionResult GetAll()
        {

            var items = _todoItemService.Get();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(TodoItemDto), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = _todoItemService.Get(id);

                return Ok(item);
            }
            catch (TodoItemNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(TodoItemDto), 201)]
        public IActionResult Create(TodoItemDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainItem = _todoItemDtoFactory.Create(item);
            var newItem = _todoItemService.Add(domainItem);

            return Created("", newItem);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(TodoItemDto), 200)]
        public IActionResult Update(TodoItemDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainItem = _todoItemDtoFactory.Create(item);
            var updatedItem = _todoItemService.Update(domainItem);

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult Delete(int id)
        {
            _todoItemService.Delete(id);

            return Ok();
        }
    }
}