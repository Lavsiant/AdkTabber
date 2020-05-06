﻿using Model.TabModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Interfaces
{
    public interface ITabRepository : IBaseRepository<Tab>
    {
        Task<List<Tab>> GetAllTabsByType(TabType type);

        Task<Tab> GetConcreteFullTab(int id);
    }
}
