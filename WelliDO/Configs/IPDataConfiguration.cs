using Microsoft.Extensions.Configuration;

namespace WelliDO.Configs
{
    public class IPDataConfiguration
    {
        private const string _apiKey = "apikey";
        private string _configSection = "IPDataAPI";
        private const string _appSettings = "appsettings.json";
        private const string _urlBase = "urlbase";

        private IConfigurationRoot GetConfigurationRoot() => new ConfigurationBuilder().AddJsonFile(_appSettings).Build();
        private string GetConfigurationString(string configSection) => GetConfigurationRoot()[configSection];
        private string GetSection(string section) => GetConfigurationString($"{_configSection}:{section}");


        public string GetAPIKey() => GetSection(_apiKey);
        public string GetUrl() => GetSection(_urlBase);


    }
}
