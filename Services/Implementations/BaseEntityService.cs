using DbRepository.Interfaces;
using DbRepository.Repositories;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class BaseEntityService<TEntity, TRepository> : IBaseEntityService<TEntity> where TRepository : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly TRepository _baseEntityRepository;

        public BaseEntityService(TRepository repository)
        {
            _baseEntityRepository = repository;
        }

        public async Task<ServiceResultWithModel<IEnumerable<TEntity>>> GetAllAsync()
        {
            var entities = await _baseEntityRepository.GetAllAsync();
            return ServiceResultWithModel<IEnumerable<TEntity>>.Success(entities);
        }

        public async Task<ServiceResultWithModel<TEntity>> GetByIdAsync(int id)
        {
            var entity = await _baseEntityRepository.GetByIdAsync(id);
            if(entity == null)
            {
                return ServiceResultWithModel<TEntity>.Failed("Not found with specific id");
            }
            return ServiceResultWithModel<TEntity>.Success(entity);
        }

        public async Task<ServiceResult> Remove(TEntity entity)
        {
            await _baseEntityRepository.Remove(entity);
            return ServiceResult.Success;
        }

        public async Task<ServiceResult> RemoveRange(IEnumerable<TEntity> entities)
        {
            await _baseEntityRepository.RemoveRange(entities);
            return ServiceResult.Success;
        }
    }
}
