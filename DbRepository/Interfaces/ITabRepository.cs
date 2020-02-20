using Model.TabModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Interfaces
{
    public interface ITabRepository<TEntity> : IBaseRepository<TEntity>
    {
        Task<List<Tab>> GetAllTabsByType(TabType type);

        Task<T> GetConcreteTypeTab<T>(int id) where T : Tab;
    }
}
