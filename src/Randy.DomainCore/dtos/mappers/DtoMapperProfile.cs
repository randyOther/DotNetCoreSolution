using AutoMapper;
using Randy.DomainCore.DTO;
using Randy.Infrastructure.entities;

namespace Randy.DomainCore.dtos
{
    public class DtoMapperProfile : Profile
    {
        /// <summary>
        /// dto mapping config
        /// </summary>
        protected override void Configure()
        {
            CreateMap<ls_user, User>();
            CreateMap<UserInfo, ls_user_info>();
        }
    }
}
