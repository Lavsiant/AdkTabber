using AdkTabber.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.SongModel;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdkTabber.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<Song>> GetSongById(int id)
        {
            var result = await _songService.GetSongWithTabs(id);
            if (result.Succeeded)
            {
                return result.Model;
            }
            return BadRequest(result.Model);
        }

        [HttpPost]
        [Route("сreate")]
        public async Task<ActionResult<Song>> CreateSong(SongCreateViewModel model)
        {
            var result = await _songService.AddSong(_mapper.Map<SongDTO>(model));
            return result.Succeeded ? (ActionResult)Ok(result.Model) : BadRequest(result.Error);
        }

    }
}
