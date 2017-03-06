using AutoMapper;
using Randy.DomainCore.DTO;
using Randy.DomainCore.eventHandler;
using Randy.FrameworkCore;
using Randy.FrameworkCore.reposiories;
using Randy.Infrastructure;
using Randy.Infrastructure.entities;
using Randy.Infrastructure.interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    [LogRequest]
    public class UserService : ApplicationServices, IUserService
    {

        public IRepository<ls_user> UserRepository { get; set; }
        public IEventBus EventBus { get; set; }

        public ReturnModel<User> Login(string userName, string password, string ip = "")
        {
            ReturnModel<User> result = new ReturnModel<DTO.User>();
            var repository = UserRepository.Get(s => (s.Email == userName || s.Phone == userName) && s.Pwd == password);
            if (repository != null)
            {
                result.Success = true;
                result.RerutnModel = Mapper.Map<User>(repository);
                EventBus.Trigger(new LoginEventData { UserId = repository.UserId, LoginIp = ip });
            }
            return result;
        }

        public ReturnModel SignUp(SignUpInput input)
        {
            var now = DateTime.Now;
            ReturnModel result = new ReturnModel();

            var repository = UserRepository.Get(s => (s.Email == input.UserName || s.Phone == input.UserName));
            if (repository != null)
            {
                result.ReturnMessage = "用户名重复/User Name is Duplicated";
            }
            else
            {
                var lsUser= UserRepository.Insert(new ls_user
                {
                    Email = input.UserName,
                    Pwd = Encryptor.Md5Encrypt(input.Password + now.ToString("yyyyMMddHHmmss"))
                });
                result.Success = true;
            }

            return result;
        }
    }

}
