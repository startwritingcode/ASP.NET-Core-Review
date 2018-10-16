using Microsoft.EntityFrameworkCore;
using TodoCore.Data.Entities;

namespace TodoCore.Data
{
    public class TodoListContext: DbContext
    {
        public DbSet<TodoListEntity> TodoLists { get; set; }
        public DbSet<TodoItemEntity> TodoItems { get; set; }
    }
}
