using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Domain;
using Todo.Domain.Exceptions.TodoList;
using Todo.Services;
using TodoCore.Dtos;
using TodoCore.Factories;

namespace TodoCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly ITodoListService _todoListService;
        private readonly ITodoListDtoFactory _todoListDtoFactory;

        public TodoListsController(ITodoListService todoListService, ITodoListDtoFactory todoListDtoFactory)
        {
            _todoListService = todoListService;
            _todoListDtoFactory = todoListDtoFactory;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoListDto>), 200)]
        public IActionResult GetAll()
        {

            var lists = _todoListService.Get();
            return Ok(lists);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(TodoListDto), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var list = _todoListService.Get(id);

                return Ok(list);
            }catch(TodoListNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(TodoListDto), 201)]
        public IActionResult Create(TodoListDto list)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainList = _todoListDtoFactory.Create(list);
            var newList = _todoListService.Add(domainList);

            return Created("", newList);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(TodoListDto), 200)]
        public IActionResult Update(TodoListDto list)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainList = _todoListDtoFactory.Create(list);
            var updatedList = _todoListService.Update(domainList);

            return Ok(updatedList);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult Delete(int id)
        {
            _todoListService.Delete(id);

            return Ok();
        }
    }
}