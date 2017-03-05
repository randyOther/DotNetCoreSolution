using Randy.FrameworkCore;
using Randy.FrameworkCore.ioc;
using Randy.FrameworkCore.reposiories;
using Randy.Infrastructure.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore.eventHandler
{

    public class LoginEventHandler : IEventHandler<LoginEventData>
    {
        //todo: 这样不能注入此类  需完善 
        //public IRepository<ls_user> UserRepository { get; set; }

        public void HandleEvent(LoginEventData eventData)
        {
            var UserRepository= IocManager.Instance.Resolve<IRepository<ls_user>>();
            var one = UserRepository.Get(s => s.UserId == eventData.UserId);
            if (one == null)
                return;
            one.LastLoginTime = DateTime.Now;
            one.LastLoginIP = eventData.LoginIp;
            UserRepository.UpdateAsync(one);
        }
    }
}
