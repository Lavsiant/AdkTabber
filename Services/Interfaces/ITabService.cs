using Model.TabModel;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITabService : IBaseEntityService<Tab>
    {
        Task<ServiceResult> CreateTabs(List<Tab> tabs, int songId);
    }
}
