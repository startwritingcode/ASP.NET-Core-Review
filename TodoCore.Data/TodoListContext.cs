using Microsoft.EntityFrameworkCore;
using TodoCore.Data.Entities;

namespace TodoCore.Data
{
    public class TodoListContext: DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options): base(options)
        {

        }

        public DbSet<TodoListEntity> TodoLists { get; set; }
        public DbSet<TodoItemEntity> TodoItems { get; set; }
    }
}
