using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.PlatformAbstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System;

namespace Randy.Infrastructure
{
    public class JsonWebTokenSource
    {
        /// <summary>
        /// 签发者名称
        /// </summary>
        public static readonly string JwtIssuer = "RandyIssuer";
        /// <summary>
        /// token 有效期（1天）
        /// </summary>
        public static readonly int ExpiresMinutes = 24 * 60;

        public static readonly string CommonAudience = "common-audience";

        static JsonWebTokenSource()
        {
            _tokenOptions = new JWTTokenOptions();

            // 从文件读取密钥
            string keyDir = PlatformServices.Default.Application.ApplicationBasePath;
            RSAParameters keyParams;
            if (Encryptor.TryGetRSAKeyParameters(keyDir, true, out keyParams) == false)
            {
                keyParams = Encryptor.GenerateAndSaveRSAKey(keyDir);
            }
            _tokenOptions.Key = new RsaSecurityKey(keyParams);
            _tokenOptions.Issuer = JwtIssuer; 
            _tokenOptions.Credentials = new SigningCredentials(_tokenOptions.Key, SecurityAlgorithms.RsaSha256Signature);
            _tokenOptions.Audience = CommonAudience; 
        }

        public static JWTTokenOptions _tokenOptions { get; set; }

        public static string GetToken(bool isAdmin, string userInfoJson, string userName)
        {
            var handler = new JwtSecurityTokenHandler();
            string jti = userName;  //todo: 应改为唯一标识,，用来标识 Token；
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim("jti",jti,ClaimValueTypes.String), // jti，用来标识 token , 让其进入黑名单则可以失效token 不然只能等到到期时间
                new Claim("userInfo",userInfoJson,ClaimValueTypes.String),
            };
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(userName, "TokenAuth"), claims);

            var expiresTime = DateTime.Now.AddMinutes(JsonWebTokenSource.ExpiresMinutes);

            if (isAdmin)
            {
                expiresTime = DateTime.Now.AddDays(30);
            }

            var token = handler.CreateEncodedJwt(new SecurityTokenDescriptor
            {
                Issuer = JsonWebTokenSource._tokenOptions.Issuer, // 指定 Token 签发者，也就是这个签发服务器的名称
                Audience = JsonWebTokenSource._tokenOptions.Audience, // 指定 Token 接收者
                SigningCredentials = JsonWebTokenSource._tokenOptions.Credentials,
                Subject = identity,
                Expires = expiresTime
            });

            return "Bearer " + token;
        }
    }

    /// <summary>
    /// jwt 实体
    /// </summary>
    public class JWTTokenOptions
    {
        public string Audience { get; set; }
        public RsaSecurityKey Key { get; set; }
        public SigningCredentials Credentials { get; set; }
        public string Issuer { get; set; }
    }
}
