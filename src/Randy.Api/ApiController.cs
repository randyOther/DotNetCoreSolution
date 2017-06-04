using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize("Bearer")]
    public abstract class ApiBaseController:Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //读取claim值  
            var jti = context.HttpContext.User.FindFirst("jti");

            Console.WriteLine("before OnActionExecuting: " + jti);
            base.OnActionExecuting(context);
        }
    }
}
