using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBaseEntityService<TEntity>
    {
        Task<ServiceResultWithModel<IEnumerable<TEntity>>> GetAllAsync();

        Task<ServiceResultWithModel<TEntity>> GetByIdAsync(int id);

        Task<ServiceResult> Remove(TEntity entity);

        Task<ServiceResult> RemoveRange(IEnumerable<TEntity> entities);

    }
}
