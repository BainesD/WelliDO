using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WelliDO.Configs;

namespace WelliDO.Tests
{
    public class GMapsConfigurationTests1
    {
        [Fact]
        public void GMapsConfiguration_GetURL_ReturnsUrlBase()
        {
            var config = new GMapsConfiguration();

            var expected = "https://maps.googleapis.com/maps/api/place/";
            var actual = config.GetUrl();

            Assert.Equal(expected, actual);
        }
    }
}
