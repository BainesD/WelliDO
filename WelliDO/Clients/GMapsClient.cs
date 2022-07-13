using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WelliDO.Configs;
using WelliDO.APIResponses.GMapsResponses;
using System.Linq;

namespace WelliDO.Clients
{
    public class GMapsClient
    {
        private readonly string _url;
        private readonly string _apikey;
        private readonly HttpClient _client = new HttpClient();

        public GMapsClient(GMapsConfiguration config)
        {
            _url = config.GetUrl();
            _apikey = config.GetAPIKey();
        }
        

        private string GetURLNearby(string location, string radius) => $"{_url}nearbysearch/json?location={location}&radius={radius}&key={_apikey}";
        private string GetURLNearby(string location, string radius, string keyword) => $"{_url}nearbysearch/json?keyword={keyword}&location={location}&radius={radius}&key={_apikey}";

        public async Task<GMapsNearbySearchResponse> GetNearbySearchAsync(float lat, float lon, string radius) 
        {

            var location = LocationParser(lat, lon);
            var response = await _client.GetStringAsync(GetURLNearby(location,radius));
            return response == null ? null! : JsonSerializer.Deserialize<GMapsNearbySearchResponse>(response)!;
        }
        public async Task<GMapsNearbySearchResponse> GetNearbySearchWKeywordAsync(float lat, float lon, string radius, string keyword)
        {
            var location = LocationParser(lat, lon);
            var response = await _client.GetStringAsync(GetURLNearby(location, radius, keyword));
            return response == null ? null! : JsonSerializer.Deserialize<GMapsNearbySearchResponse>(response)!;
        }

        public static string LocationParser(float lat, float lon)
        { 
            return $"{lat}%2C{lon}";
        }


    }
}
