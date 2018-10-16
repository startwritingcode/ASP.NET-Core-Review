using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoCore.Dtos
{
    public class TodoListDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public List<TodoItemDto> Items { get; set; }
    }
}
