using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Modelo.Domain.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        bool Delete(object primaryKeyObject);
        void Add(TEntity entity);
        bool Update(object primaryKeyObject, TEntity entity);
        TEntity Find(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
        int Commit();
    }
}
