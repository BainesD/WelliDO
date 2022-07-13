using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WelliDO.APIResponses;
using WelliDO.Configs;

namespace WelliDO.Clients
{
    public class IPDataClient
    {
        private readonly string _url;
        private readonly string _apikey;
        private readonly HttpClient _client = new HttpClient();

        public IPDataClient(IPDataConfiguration config)
        {
            _url = config.GetUrl();
            _apikey = config.GetAPIKey();
        }

        private string GetIPDataUrl() => $"{_url}?api-key={_apikey}";
        public async Task<IPDataResponses> GetIPData()
        {
            var response = await _client.GetStringAsync(GetIPDataUrl());
            return response == null ? null! : JsonSerializer.Deserialize<IPDataResponses>(response)!;
        }
    }
}
