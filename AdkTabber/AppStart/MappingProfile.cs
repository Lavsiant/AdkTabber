using AdkTabber.ViewModels.AuthViewModels;
using AutoMapper;
using Model.UserModel;
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
        }
    }
}
