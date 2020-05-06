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
    public class TabRepository : BaseRepository<Tab>, ITabRepository
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

        public async Task<Tab> GetConcreteFullTab(int id) 
        {
            var tab = _context.Tabs.First(x => x.ID == id);
            return tab.Type switch
            {
                TabType.Guitar => await _context.GuitarTabs.Include(x=>x.Iterations).FirstOrDefaultAsync(x=>x.ID==id),
                TabType.Drums => await _context.DrumTabs.Include(x => x.Iterations).FirstOrDefaultAsync(x => x.ID == id),
                TabType.Piano => await _context.PianoTabs.Include(x => x.Iterations).FirstOrDefaultAsync(x => x.ID == id),
                _ => await _context.Tabs.FirstOrDefaultAsync(x => x.ID == id),
            };          
        }

    }
}
