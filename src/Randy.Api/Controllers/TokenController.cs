using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Randy.Infrastructure;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// Token Controller
    /// </summary>
    [Route("[controller]/[action]")]
    public class TokenController : Controller
    {

        /// <summary>
        ///  test interface：  create new token , WARNING [close this interface in production envrionment]
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string CreateToken()
        {
            var adminName = "administrator";
            var detail = new DomainCore.DTO.UserInfo
            {
                RealName = adminName
            };
            return JsonWebTokenSource.GetToken(true, JsonSerialize.ToJson(detail), adminName);
        }

        /// <summary>
        /// add token key to black list
        /// </summary>
        /// <param name="key">key ['userid-username']</param>
        /// <returns></returns>
        [HttpGet("{key}")]
        public bool InvalidToken(string key)
        {
            return JwtBlackList.Add(key, "values");
        }

        /// <summary>
        /// remove token by key from black list
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("{key}")]
        public string EmptyBlacToken(string key = null)
        {
            return JwtBlackList.Remove(key);
        }

    }


}
