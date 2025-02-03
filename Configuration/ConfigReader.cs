using Microsoft.Extensions.Configuration;

namespace Entain.Configuration
{
    public static class ConfigReader
    {
        public static IConfigurationRoot LoadConfig()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config;
        }

        public static string GetDevice(this IConfiguration configuration)
        {
            string? device = configuration.GetValue<string>("Device");
            if (string.IsNullOrWhiteSpace(device))
            {
                throw new ArgumentException("Device is not set in congfiguration");
            }

            return device;
        }

        public static (int width, int height) GetViewportSize(this IConfiguration configuration, string deviceType)
        {
            int width = configuration.GetValue<int>($"ViewportSettings:{deviceType}:Width");
            int height = configuration.GetValue<int>($"ViewportSettings:{deviceType}:Height");
            return (width, height);
        }
    }

}
