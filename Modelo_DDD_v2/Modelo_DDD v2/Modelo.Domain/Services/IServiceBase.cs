using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Modelo.Domain.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity FindByExpression(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> FindAllByExpression(Expression<Func<TEntity, bool>> expression);
        int Add(TEntity entity);
        int Update(TEntity entity);
    }
}
