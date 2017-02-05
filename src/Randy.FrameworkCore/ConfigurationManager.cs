using Microsoft.Extensions.Configuration;
using System.IO;

namespace Randy.FrameworkCore
{
    /// <summary>
    /// get configration through appsettings.json
    /// </summary>
    public class ConfigurationManager
    {
        private static IConfiguration config;

        static ConfigurationManager()
        {
            if (config == null)
                config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
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
