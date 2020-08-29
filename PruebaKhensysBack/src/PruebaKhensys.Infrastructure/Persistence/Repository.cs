using Microsoft.EntityFrameworkCore;
using PruebaKhensys.Core.Interfaces.Persistence;
using PruebaKhensys.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaKhensys.Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;

        public Repository(DbSet<TEntity> entities) => _entities = entities;

        //Add:
        public void Add(TEntity entity) => _entities.Add(entity);
        public async Task AddAsync(TEntity entity) => await _entities.AddAsync(entity);
        public void AddRange(IEnumerable<TEntity> entities) => _entities.AddRange(entities);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _entities.AddRangeAsync(entities);
        
        //Delete:
        public void Delete(TEntity entity) => _entities.Remove(entity);
        public async Task DeleteAsync(TEntity entity) => await Task.Run(() => { Delete(entity); });
        public void DeleteRange(IEnumerable<TEntity> entities) => _entities.RemoveRange(entities);
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities) => await Task.Run(() => { _entities.RemoveRange(entities); });

        //Get:
        public TEntity Find(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude) => _entities.Find(predicates);
        public async Task<TEntity> FindAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude) => await _entities.FindAsync(predicates);
        public IEnumerable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude) => _entities.Filter(predicates).Include(entitiesToInclude).AsEnumerable();
        public async Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, IEnumerable<string> entitiesToInclude) => await _entities.Filter(predicates).Include(entitiesToInclude).ToListAsync();
        public TEntity GetById(int id, IEnumerable<string> entitiesToInclude) => _entities.Find(id);
        public async Task<TEntity> GetByIdAsync(int id, IEnumerable<string> entitiesToInclude) => await _entities.FindAsync(id);

        //Update:
        public void Update(TEntity entity) => _entities.Update(entity);
        public async Task UpdateAsync(TEntity entity) => await Task.Run(() => { _entities.Update(entity); });
        public void UpdateRange(IEnumerable<TEntity> entities) => _entities.UpdateRange(entities);
        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities) => await Task.Run(() => { _entities.UpdateRange(entities); });

        //
        public async virtual Task<int> Count(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null) => await _entities.Filter(predicates).CountAsync();
        public bool Exist(Expression<Func<TEntity, bool>> predicate) => _entities.Any(predicate);
        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate) => await _entities.AnyAsync(predicate);

    }
}
