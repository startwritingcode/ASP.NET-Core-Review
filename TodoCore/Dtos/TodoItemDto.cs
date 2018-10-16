using System.ComponentModel.DataAnnotations;

namespace TodoCore.Dtos
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
