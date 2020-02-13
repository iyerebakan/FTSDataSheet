using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int skip = 0, int take = 0, string includeProperties = "");
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Expression<Func<T, bool>> filter = null);
    }
}
