using AutoMapper;
using DbRepository.Interfaces;
using Model.SongModel;
using Services.DTOs;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class SongService : BaseEntityService<Song, ISongRepository>, ISongService
    {
        private readonly IMapper _mapper;

        public SongService(ISongRepository songRepository, IMapper mapper) : base(songRepository)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResultWithModel<Song>> GetSongWithTabs(int songId)
        {
            var song = await _baseEntityRepository.GetSongWithTabs(songId);
            if(song == null)
            {
                return ServiceResultWithModel<Song>.Failed("Song not found");
            }
            return ServiceResultWithModel<Song>.Success(song);
        }

        public async Task<ServiceResultWithModel<Song>> AddSong(SongDTO songModel)
        {

            try
            {
                var song = _mapper.Map<Song>(songModel);
                await _baseEntityRepository.AddAsync(song);
                return ServiceResultWithModel<Song>.Success(song);
            }
            catch(Exception e)
            {
                return ServiceResultWithModel<Song>.Failed(e.Message);
            }
        }
    }
}
