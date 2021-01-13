using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAssignment.Models;
using DbAssignment.DTO;

namespace DbAssignment.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
        }
    }
}
