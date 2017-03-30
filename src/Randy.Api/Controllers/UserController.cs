using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Randy.DomainCore;
using Randy.DomainCore.DTO;
using Randy.Infrastructure;
using Randy.Api.Models;
using Randy.Infrastructure.entities;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// User application service
    /// </summary>
    //[Route("api/[controller]/[action]")]
    public class UserController : ApiBaseController
    {

        public IUserService UserService { get; set; }

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        /// <summary>
        /// Login for user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel<User> Login([FromBody]LoginRequest request)
        {
            return UserService.Login(request.UserName, request.Password,HttpContext.Connection.RemoteIpAddress.ToString());
   
        }


        /// <summary>
        /// SignUp User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel SignUp([FromBody]SignUpInput request)
        {
            return UserService.SignUp(request);
        }

        /// <summary>
        /// User info list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnPagedModel<ls_user_info> GetUserInfos([FromBody]QueryPagedModel query)
        {
            return UserService.GetUserInfos(query);
        }



        /// <summary>
        /// Set User info
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel SetUserInfo([FromBody]UserInfo request)
        {
            return UserService.SetUserInfo(request);
        }


        /// <summary>
        /// get GetParam test
        /// </summary>
        /// <returns>empty</returns>
        [HttpGet("{id}/{code}")]
        public string GetParam(int id, int code)
        {
            return id + "【Get】" + code;
        }

    }

   
}
