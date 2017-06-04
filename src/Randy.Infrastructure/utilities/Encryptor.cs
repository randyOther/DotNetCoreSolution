using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Randy.Infrastructure
{
    public class Encryptor
    {

        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Md5Encrypt(string inputValue)
        {
            var res = "";
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(inputValue));
                var strResult = BitConverter.ToString(result);
                res = strResult.Replace("-", "");
            }
            return res;
        }

        //AES/DES 对称
        //public static T JsonToObject<T>(string input)
        //{
        //    return JsonConvert.DeserializeObject<T>(input);
        //}


        //RSA 非对称
        /// <summary>
        /// 生成并保存 RSA 公钥与私钥
        /// </summary>
        /// <param name="filePath">存放密钥的文件夹路径</param>
        /// <returns></returns>
        public static RSAParameters GenerateAndSaveRSAKey(string filePath)
        {
            RSAParameters publicKeys, privateKeys;
            using (var rsa = new System.Security.Cryptography.RSACryptoServiceProvider(2048))
            {
                try
                {
                    privateKeys = rsa.ExportParameters(true);
                    publicKeys = rsa.ExportParameters(false);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            File.WriteAllText(Path.Combine(filePath, "key.json"), JsonConvert.SerializeObject(privateKeys));
            File.WriteAllText(Path.Combine(filePath, "key.public.json"), JsonConvert.SerializeObject(publicKeys));
            return privateKeys;
        }

        /// <summary>
        /// 从本地文件中读取用来签发的 RSA Key
        /// </summary>
        /// <param name="filePath">存放密钥的文件夹路径</param>
        /// <param name="withPrivate">获取私钥/公钥</param>
        /// <param name="keyParameters"></param>
        /// <returns></returns>
        public static bool TryGetRSAKeyParameters(string filePath, bool withPrivate, out System.Security.Cryptography.RSAParameters keyParameters)
        {
            string filename = withPrivate ? "key.json" : "key.public.json";
            keyParameters = default(RSAParameters);
            if (Directory.Exists(filePath) == false) return false;
            keyParameters = JsonConvert.DeserializeObject<RSAParameters>(File.ReadAllText(Path.Combine(filePath, filename)));
            return true;
        }

    }

}
