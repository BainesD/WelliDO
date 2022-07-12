using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
namespace WelliDO.Configs
{
    public class GMapsConfiguration
    {
        private const string _apiKey = "apikey";
        private string _configSection = "GoogleMapsAPI";
        private const string _appSettings = "appsettings.json";
        private const string _urlBase = "urlbase";


        private string GetSection(string section) => GetConfigurationString($"{_configSection}:{section}");

        private string GetConfigurationString(string configSection) => GetConfigurationRoot()[configSection];

        private IConfigurationRoot GetConfigurationRoot() => new ConfigurationBuilder().AddJsonFile(_appSettings).Build();

        public string GetAPIKey() => GetSection(_apiKey);

        public string GetUrl() => GetSection(_urlBase);

       
    }
}
