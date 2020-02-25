using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBaseEntityService<TEntity>
    {
        Task CreateAsync(TEntity entity);

        Task Create(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task Remove(TEntity entity);

        Task RemoveRange(IEnumerable<TEntity> entities);

    }
}
