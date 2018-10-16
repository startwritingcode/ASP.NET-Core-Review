using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoCore.Data.Entities
{
    [Table("TodoItems")]
    public class TodoItemEntity: Entity, IEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public int TodoListId { get; set; }
        public TodoListEntity List { get; set; }
    }
}
