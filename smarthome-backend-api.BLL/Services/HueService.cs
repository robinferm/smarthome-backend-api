using smarthome_backend_api.BLL.Models;
using smarthome_backend_api.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace smarthome_backend_api.BLL.Services
{
    public class HueService : IHueService
    {
        private static HttpClientHandler _clientHandler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        };

        private readonly HttpClient _client = new HttpClient(_clientHandler);
        private readonly string _username;
        private readonly string _baseURL;

        public HueService()
        {
            _username = Environment.GetEnvironmentVariable("hue-username");
            _baseURL = Environment.GetEnvironmentVariable("hue-url");
        }

        public async Task<Dictionary<string, Id>> GetScenes()
        {
            string url = _baseURL + _username + "/scenes";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            string stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, Id>>(stringResponse);
            

            return result;
        }

        public async Task<Light> TurnOff(int id)
        {
            string url = _baseURL + _username + $"/lights/{id}/state";
            HttpContent test = new StringContent("{\"on\":false}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(url, test);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            string stringResponse = await response.Content.ReadAsStringAsync();
            Light result = JsonSerializer.Deserialize<Light>(stringResponse);

            return result;
        }

        public async Task<Light> TurnOn(int id)
        {
            string url = _baseURL + _username + $"/lights/{id}/state";
            HttpContent test = new StringContent("{\"on\":true}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(url, test);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            string stringResponse = await response.Content.ReadAsStringAsync();
            Light result = JsonSerializer.Deserialize<Light>(stringResponse);

            return result;
        }
    }
}
