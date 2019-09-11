using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Repositories;
using Modelo.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Modelo.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDataContext _dataContext;

        public RepositoryBase(ApplicationDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
        }

        public bool Delete(object primaryKeyObject)
        {
            var entity = _dataContext.Set<TEntity>().Find(primaryKeyObject);
            if (entity == null)
                return false;

            _dataContext.Set<TEntity>().Remove(entity);
            return true;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return _dataContext.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return _dataContext.Set<TEntity>().Where(expression).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().AsNoTracking().AsEnumerable();
        }

        public TEntity GetById(object id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public bool Update(object primaryKeyObject, TEntity entity)
        {
            var result = _dataContext.Set<TEntity>().Find(primaryKeyObject);

            if (result == null)
                return false;

            _dataContext.Set<TEntity>().Update(entity);

            return true;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public int Commit()
        {
            return _dataContext.SaveChanges();
        }
    }
}
