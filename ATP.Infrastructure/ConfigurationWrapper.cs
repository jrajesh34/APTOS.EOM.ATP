using ATP.Infrastructure.Interfaces;
using EOM.Kernel.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ATP.Infrastructure
{
    public class ConfigurationWrapper : IConfigurationManagerWrapper, IConnectionStringProvider
    {
        private const string Settings = "AppConfig";

        private readonly IConfiguration configuration;

        public ConfigurationWrapper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetAppSettings(string path)
        {
            return GetAppSettings(path, null);
        }

        public string GetAppSettings(string path, string defaultValue)
        {
            var envSettings = configuration.GetSection(path)?.Value ?? defaultValue;

            if (!string.IsNullOrEmpty(envSettings))
                return envSettings;

            var value = configuration[$"{Settings}:{path}"];
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        public string GetConnectionString(string name)
        {
            return GetAppSettings(name, null);
        }

        public string GetConnectionString()
        {
            return GetAppSettings("Aptos_ConnectionString");
        }

        public void SetConnectionString(string connectionString)
        {
            throw new System.NotImplementedException();
        }
    }
}
