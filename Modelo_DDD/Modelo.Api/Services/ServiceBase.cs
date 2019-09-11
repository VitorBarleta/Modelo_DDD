using Modelo.Domain.Repositories;
using Modelo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Modelo.Api.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>, IDisposable where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual bool Delete(object primaryKeyObject)
        {
            return _repository.Delete(primaryKeyObject);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Find(expression);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.FindAll(expression);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }

        public virtual bool Update(object primaryKeyObject, TEntity entity)
        {
            return _repository.Update(primaryKeyObject, entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public int Commit()
        {
            return _repository.Commit();
        }
    }
}
