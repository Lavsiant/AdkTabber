using DbRepository.Interfaces;
using Model.SongModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepository.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(DataContext context) : base(context) { }
    }
}
