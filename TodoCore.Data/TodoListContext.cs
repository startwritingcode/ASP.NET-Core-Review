using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public override int SaveChanges()
        {
            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            addedEntities.ForEach(e => {
                var utcDate = DateTime.UtcNow;
                e.Property("CreatedDate").CurrentValue = utcDate;
                e.Property("UpdatedDate").CurrentValue = utcDate;
            });


            var updatedEnities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            updatedEnities.ForEach(e => e.Property("UpdatedDate").CurrentValue = DateTime.UtcNow);

            return base.SaveChanges();
        }
    }
}
