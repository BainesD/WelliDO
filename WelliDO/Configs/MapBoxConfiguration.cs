using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WelliDO.Configs
{
    public class MapBoxConfiguration
    {
        #region Environment
        private const string _apiKey = "apikey";
        private string _configSection = "MapBoxAPI";
        private const string _appSettings = "appsettings.json";
        private const string _urlBase = "urlbase";
        #endregion

        #region Read appsettings
        private string GetSection(string section) => GetConfigurationString($"{_configSection}:{section}");

        private string GetConfigurationString(string configSection) => GetConfigurationRoot()[configSection];

        private IConfigurationRoot GetConfigurationRoot() => new ConfigurationBuilder().AddJsonFile(_appSettings).Build();
        #endregion

        #region Configure Data
        public string GetAPIKey() => GetSection(_apiKey);

        public string GetUrl() => GetSection(_urlBase);

        #endregion
    }
}
