using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Randy.Application;

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
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>id user</returns>
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return new Controllers.User { id = id, name = id + "-randy", age = 11 };
        }

        /// <summary>
        /// get by post method
        /// </summary>
        /// <returns>default user</returns>
        [HttpPost]
        public User GetUser()
        {
            return new Controllers.User { id = 99, name = 99 + "-randy", age = 100 };
        }


        /// <summary>
        /// get GetTwoParam
        /// </summary>
        /// <returns>empty</returns>
        [HttpGet("{id}/{code}")]
        public string GetTwoParam(int id, int code)
        {
            return id + "one" + code;
        }

        /// <summary>
        /// del user
        /// </summary>
        /// <param name="user">delete the user</param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete([FromBody]User user)
        {
            return true;
        }

    }

    /// <summary>
    /// User model
    /// </summary>
    public class User
    {
        /// <summary>
        /// id only
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// age
        /// </summary>
        public int age { get; set; }

    }
}
