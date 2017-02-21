using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [Route("[controller]/[action]")]
    public abstract class ApiBaseController:Controller
    {
    }
}
