using DbRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.SongModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(DataContext context) : base(context) { }

        public async Task<Song> GetSongWithTabs(int songId)
        {
            return await _context.Songs.Include(x => x.Tabs).FirstOrDefaultAsync(x=>x.ID == songId);
        }


    }
}
