using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaKhensys.Core.Interfaces.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Add:
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        //Get:
        TEntity GetById(int id, IEnumerable<string> entitiesToInclude = null);
        Task<TEntity> GetByIdAsync(int id, IEnumerable<string> entitiesToInclude = null);
        //Add pagination:
        IEnumerable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null);
        Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null);
        TEntity Find(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null);
        Task<TEntity> FindAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null);

        //Update:
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        //Delete:
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        //
        Task<int> Count(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null);
        bool Exist(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);


    }
}
