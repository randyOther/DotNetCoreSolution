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
    public class TokenController
    {

        /// <summary>
        /// 生成一个新的 Token
        /// </summary>
        /// <param name="user">用户信息实体</param>
        /// <param name="expire">token 过期时间</param>
        /// <param name="audience">Token 接收者</param>
        /// <returns></returns>
        [HttpPost]
        public string CreateToken()
        {
            var user = "randy";
       
            var handler = new JwtSecurityTokenHandler();
            string jti = user;
            //jti = jti.GetMd5(); // Jwt 的一个参数，用来标识 Token
            var claims = new[]
            {
                //new Claim(ClaimTypes.Role, role), // 添加角色信息
                new Claim(ClaimTypes.NameIdentifier, user), // 用户 Id ClaimValueTypes.Integer32),
                new Claim("jti",jti,ClaimValueTypes.String), // jti，用来标识 token , 让其进入黑名单则可以失效token 不然只能等到到期时间
               new Claim("userInfo","user json info value",ClaimValueTypes.String),
            };
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user, "TokenAuth"), claims);
            var token = handler.CreateEncodedJwt(new SecurityTokenDescriptor
            {
                Issuer = JsonWebTokenSource._tokenOptions.Issuer, // 指定 Token 签发者，也就是这个签发服务器的名称
                Audience = JsonWebTokenSource._tokenOptions.Audience, // 指定 Token 接收者
                SigningCredentials = JsonWebTokenSource._tokenOptions.Credentials,
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(JsonWebTokenSource.ExpiresMinutes)
            });

            return "Bearer " + token;
        }

        /// <summary>
        /// add token to black list
        /// </summary>
        /// <param name="key">key ['userid-username']</param>
        /// <returns></returns>
        [HttpGet("{key}")]
        public bool InvalidToken(string key)
        {
            return JwtBlackList.Add(key, "values");
        }


    }


}
