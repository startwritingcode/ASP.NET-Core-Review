using TodoCore.Data;
using TodoCore.Data.Entities;

namespace Todo.Repositories
{
    public interface ITodoItemRepository: IRepository<TodoItemEntity>
    {

    }

    public class TodoItemRepository : Repository<TodoItemEntity>, ITodoItemRepository
    {
        protected TodoItemRepository(TodoListContext context) : base(context)
        {
        }
    }
}
