using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triangle.UserManagement.Core.Model.UserAggregate;
using Triangle.Web.Models.UserManagementModels;

namespace Triangle.Web.App_Start
{
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile(new ModelsProfile()));
        }
    }

    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            base.CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
