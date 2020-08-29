using Microsoft.EntityFrameworkCore;
using PruebaKhensys.Core.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaKhensys.Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;

        public Repository(DbSet<TEntity> entities)
        {
            _entities = entities;
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id, IEnumerable<string> entitiesToInclude)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id, IEnumerable<string> entitiesToInclude)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
