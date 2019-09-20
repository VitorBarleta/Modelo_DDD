using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Modelo.Domain.Repositories;
using Modelo.Domain.Services;

namespace Modelo.Api.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual int Add(TEntity entity)
        {
            _repository.Add(entity);

            return _repository.SaveChanges();
        }
        public IEnumerable<TEntity> FindAllByExpression(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public TEntity FindByExpression(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual int Update(TEntity entity)
        {
            _repository.Update(entity);

            return _repository.SaveChanges();
        }
    }
}
