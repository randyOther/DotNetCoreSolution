using AutoMapper;
using Randy.DomainCore.DTO;
using Randy.Infrastructure.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore.dtos
{
    public class DtoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ls_user, User>();
        }
    }
}
