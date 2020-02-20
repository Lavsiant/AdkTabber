using DbRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.TabModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Repositories
{
    public class TabRepository : BaseRepository<Tab>, ITabRepository<Tab>
    {
        public TabRepository(DataContext context) : base(context) { }

        public async Task<List<Tab>> GetAllTabsByType(TabType type)
        {
            return type switch
            {
                TabType.Guitar => await _context.GuitarTabs.Cast<Tab>().ToListAsync(),
                TabType.Drums => await _context.DrumTabs.Cast<Tab>().ToListAsync(),
                _ => await _context.Tabs.ToListAsync(),
            };
        }

        public async Task<T> GetConcreteTypeTab<T>(int id) where T : Tab
        {
            return await _context.Tabs.FirstOrDefaultAsync(x => x.ID == id) is T tab ? tab : null;
        }

    }
}
