using Randy.DomainCore.DTO;
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
    [LogInterceptor]
    public class UserService : ApplicationServices, IUserService
    {

        public IRepository<ls_user> UserRepository { get; set; }

        public ReturnModel<User> Login()
        {
            ReturnModel<User> result = new ReturnModel<DTO.User>();

            return result;  
        }

        public ReturnModel LogOut()
        {
            ReturnModel result = new ReturnModel();

            return result;
        }

        public ReturnModel SignUp()
        {
            ReturnModel result = new ReturnModel();

            return result;
        }
    }

}
