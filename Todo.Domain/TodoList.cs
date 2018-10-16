using System.Collections.Generic;
using System.Linq;

namespace Todo.Domain
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TodoItem> Items { get; set; }

        public bool IsComplete => Items.Any() && Items.All(i => i.IsComplete);
    }
}
