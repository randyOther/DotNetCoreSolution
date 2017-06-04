using AutoMapper;
using Randy.DomainCore.DTO;
using Randy.Infrastructure.entities;

namespace Randy.DomainCore.dtos
{
    public class DtoMapperProfile : Profile
    {

        public DtoMapperProfile()
        {
            CreateMap<ls_user, User>();
            CreateMap<UserInfo, ls_user_info>();
            CreateMap<ls_user_info, UserInfo>();
            CreateMap<ls_role, Role>();
            CreateMap<ls_authority, Permission>();
            CreateMap<ls_company, Company>();
        }

    }
}
