using Microsoft.Extensions.Configuration;
using System.IO;

namespace Randy.Infrastructure
{
    /// <summary>
    /// get configration through appsettings.json
    /// </summary>
    public class ConfigurationManager
    {

        private static IConfiguration config;

        public static void SetConfig(IConfiguration cig)
        {
            config = cig;
        }

        public static string GetConfigValue(string name)
        {

            if (config.GetSection(name) == null)
                return "";

            return config.GetSection(name).Value;
        }

        public static IConfigurationSection GetConfigSection(string name)
        {
            return config.GetSection(name);
        }

    }
}
