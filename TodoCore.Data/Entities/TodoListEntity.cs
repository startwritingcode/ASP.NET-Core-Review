using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoCore.Data.Entities
{
    [Table("TodoLists")]
    public class TodoListEntity: Entity, IEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public ICollection<TodoItemEntity> Items { get; set; }
    }
}
