using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TodoCore.Data;
using TodoCore.Data.Entities;

namespace Todo.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T: Entity
    {
        protected TodoListContext Context;
        protected Repository(TodoListContext context)
        {
            Context = context;
        }

        public virtual T Add(T entity)
        {
            var newEntity = Context.Set<T>().Add(entity);
            Context.SaveChanges();

            return newEntity.Entity;
        }

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            Context.Set<T>().Remove(entity);

            Context.SaveChanges();
        }

        public virtual IEnumerable<T> Get()
        {
            return Context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public virtual T Get(int id)
        {
            return Context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public virtual T Update(T entity)
        {
            var attachedEntity = Context.Set<T>().Attach(entity);
            attachedEntity.State = EntityState.Modified;

            Context.SaveChanges();
            return attachedEntity.Entity;
        }
    }
}
