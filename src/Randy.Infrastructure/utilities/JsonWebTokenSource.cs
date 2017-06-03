using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.PlatformAbstractions;

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
