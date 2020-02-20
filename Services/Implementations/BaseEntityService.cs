using DbRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class BaseEntityService<TEntity, TRepository> where TRepository : BaseRepository<TEntity> where TEntity : class
    {

    }
}
