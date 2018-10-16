using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TodoCore.Data.Entities;

namespace Todo.Repositories
{
    public interface IRepository<T> where T: IEntity
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T Get(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
