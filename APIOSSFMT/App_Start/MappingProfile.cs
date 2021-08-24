using APIOSSFMT.DTO;
using AutoMapper;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIOSSFMT.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<User, UserDTO>();
           Mapper.CreateMap<UserDTO, User>();
        }
    }
}