using DbRepository.Repositories;
using Model.SongModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepository.Interfaces
{
    public interface ISongRepository : IBaseRepository<Song>
    {
    }
}
