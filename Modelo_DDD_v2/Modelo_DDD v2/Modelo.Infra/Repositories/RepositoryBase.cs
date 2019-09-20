using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Repositories;
using Modelo.Infra.Data;

namespace Modelo.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> entities;
        private readonly ApplicationDataContext _context;

        public RepositoryBase(ApplicationDataContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return entities.Where(expression).FirstOrDefault();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return entities.Where(expression).AsNoTracking().AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.AsNoTracking().AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
