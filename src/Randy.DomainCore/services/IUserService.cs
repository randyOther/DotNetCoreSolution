using Randy.DomainCore.DTO;
using Randy.FrameworkCore;
using Randy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    public interface IUserService : IDependentInjection
    {

        ReturnModel<User> Login(User user);
        ReturnModel LogOut();
        ReturnModel SignUp();
    }

}
