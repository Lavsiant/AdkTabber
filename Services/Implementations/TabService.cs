using DbRepository.Interfaces;
using DbRepository.Repositories;
using Model.TabModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class TabService : BaseEntityService<Tab,ITabRepository>, ITabService
    {
        public TabService(ITabRepository tabRepository) : base(tabRepository)
        {

        }
    }
}
