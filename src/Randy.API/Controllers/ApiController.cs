using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Randy.Api.Controllers
{
    [Route("[controller]/[action]")]
    public abstract class ApiController:Controller
    {
    }
}
