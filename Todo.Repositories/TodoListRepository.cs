using TodoCore.Data;
using TodoCore.Data.Entities;

namespace Todo.Repositories
{
    public interface ITodoListRepository: IRepository<TodoListEntity>
    {

    }

    public class TodoListRepository : Repository<TodoListEntity>, ITodoListRepository
    {
        protected TodoListRepository(TodoListContext context) : base(context)
        {
        }
    }
}
