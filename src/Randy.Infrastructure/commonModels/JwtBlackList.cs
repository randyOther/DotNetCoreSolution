using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure
{
    /// <summary>
    /// jwt black list ,limit to invoke api if in this list 
    /// </summary>
    public class JwtBlackList
    {
        private static System.Collections.Concurrent.ConcurrentDictionary<string, string> _blackrecord = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();


        public static bool Add(string key, string value)
        {
            if (_blackrecord.ContainsKey(key))
                return true;

            return _blackrecord.TryAdd(key, value);
        }

        public static string Remove(string key)
        {

            if (key == null)
            {
                _blackrecord = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();
                return "all empty";
            }

            string removeValue = null;
            if (_blackrecord.ContainsKey(key))
            {
                _blackrecord.TryRemove(key, out removeValue);
            }
            return removeValue;
        }

        public static bool IsBlackRecord(string key)
        {
            if (_blackrecord.ContainsKey(key))
                return true;
            else
                return false;
        }


    }
    
}
