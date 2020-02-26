using AdkTabber.ViewModels;
using AdkTabber.ViewModels.AuthViewModels;
using AutoMapper;
using Model.SongModel;
using Model.UserModel;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdkTabber.AppStart
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, User>();
            CreateMap<SongCreateViewModel, SongDTO>();
            CreateMap<SongDTO, Song>();
        }
    }
}
