using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
    }
}
