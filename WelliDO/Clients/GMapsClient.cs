using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WelliDO.Configs;
using WelliDO.APIResponses;

namespace WelliDO.Clients
{
    public class GMapsClient
    {
        public GMapsClient()
        {

        }
        public GMapsClient(GMapsConfiguration config)
        {
            _url = config.GetUrl();
            _apikey = config.GetAPIKey();
        }

        private readonly string _url;
        private readonly string _apikey;
        private readonly HttpClient _client = new HttpClient();

        private string GetURLNearby(string location, string radius, string type) => $"{_url}nearbysearch/json?location={location}&radius={radius}&type={type}&key={_apikey}";

        public async Task<GMapsResponseNearbySearch> GetNearbySearchAsync(string location, string radius, string type) 
        {
            var response = await _client.GetStringAsync(GetURLNearby(location,radius, type));
            return response == null ? null! : JsonSerializer.Deserialize<GMapsResponseNearbySearch>(response)!;
        }


    }
}
