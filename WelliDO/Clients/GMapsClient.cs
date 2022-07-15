using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WelliDO.Configs;
using System.Linq;
using WelliDO.APIResponses;

namespace WelliDO.Clients
{
    public class GMapsClient
    {
        private readonly string _url;
        private readonly string _apikey;
        private readonly HttpClient _client = new HttpClient();
        private readonly string _photourlbase;

        public GMapsClient(GMapsConfiguration config)
        {
            _url = config.GetUrl();
            _apikey = config.GetAPIKey();
            _photourlbase = "https://maps.googleapis.com/maps/api/place/photo";
        }

        public string CallPhotoAPI(string photoRefeerence) => $"{_photourlbase}?maxwidth=400&photo_reference={photoRefeerence}&key={_apikey}";
        private string GetURLNearby(string location, string radius) => $"{_url}nearbysearch/json?location={location}&radius={radius}&key={_apikey}";
        private string GetURLNearby(string location, string radius, string keyword) => $"{_url}nearbysearch/json?keyword={keyword}&location={location}&radius={radius}&key={_apikey}";
        private string GetPlaceDetails(string placeID) => $"{_url}details/json?place_id={placeID}&fields=name%2Cformatted_address%2Cphotos&key={_apikey}";


        public async Task<GMapsPlaceDetailsResponse> GetPlaceDetailsAsync(string placeid)
        {
            var response = await _client.GetStringAsync(GetPlaceDetails(placeid));
            return response == null ? null! : JsonSerializer.Deserialize<GMapsPlaceDetailsResponse>(response)!;
        }
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
