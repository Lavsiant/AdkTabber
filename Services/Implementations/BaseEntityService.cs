using DbRepository.Interfaces;
using DbRepository.Repositories;
using Services.Interfaces;
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
        public async Task CreateAsync(TEntity entity)
        {
            await _baseEntityRepository.AddAsync(entity);            
        }

        public async Task Create(IEnumerable<TEntity> entities)
        {
            await _baseEntityRepository.AddRangeAsync(entities);            
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseEntityRepository.Find(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _baseEntityRepository.GetAllAsync();            
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _baseEntityRepository.GetByIdAsync(id);            
        }

        public async Task Remove(TEntity entity)
        {
            await _baseEntityRepository.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            await _baseEntityRepository.RemoveRange(entities);            
        }
    }
}
