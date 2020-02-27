using DbRepository.Interfaces;
using DbRepository.Repositories;
using Model.SongModel;
using Model.TabModel;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class TabService : BaseEntityService<Tab, ITabRepository>, ITabService
    {
        private readonly ISongRepository _songRepository;

        public TabService(ITabRepository tabRepository, ISongRepository songRepository) : base(tabRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<ServiceResult> CreateTabs(List<Tab> tabs, int songId)
        {            
            if (!(await _songRepository.GetByIdAsync(songId) is Song))
            {
                return ServiceResult.Failed("Song with specific id not found");
            }
            tabs.ForEach(x => x.SongID = songId);

            try
            {
                await _baseEntityRepository.AddRangeAsync(tabs);
                return ServiceResult.Success;
            }
            catch(Exception e)
            {
                return ServiceResult.Failed(e.Message);
            }

        }

    }
}
