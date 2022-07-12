using System;
using Xunit;
using WelliDO.Configs;
using WelliDO.Clients;
using WelliDO.APIResponses;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WelliDO.Tests
{
    public class GMapsClientTests1
    {
        // Test was successful. Commented out after method's access mod was returned to private.
        //Api key was removed from expected output.

        //[Theory]
        //[InlineData("33.543682%2C-86.779633","1500","bar","https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=33.543682%2C-86.779633&radius=1500&type=bar&key=<apiKey>")]
        //public void GMapsClient_GetURLNearby_ReturnURL(string location, string radius, string type, string expected)
        //{
        //    var config = new GMapsConfiguration();
        //    GMapsClient client = new GMapsClient(config);

        //    string actual = client.GetURLNearby(location, radius, type);

        //    Assert.Equal(expected, actual);
        //}

        //[Theory]
        //[InlineData("33.543682%2C-86.779633", "1500", "bar", "G M Lounge")]
        //public void GMapsClient_GetNearbySearchAsync_ReturnResultName(string location, string radius, string type, string expected)
        //{

        //    var client = new GMapsClient(new GMapsConfiguration());
        //    var response = client.GetNearbySearchAsync(location, radius, expected).Result;



        //}
    }
}
