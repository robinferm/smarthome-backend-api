using smarthome_backend_api.BLL.Models;
using smarthome_backend_api.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace smarthome_backend_api.BLL.Services
{
    public class HueService : IHueService
    {
        private readonly HttpClient _client;
        private readonly string _username;
        private readonly string _baseURL;

        public HueService(HttpClient client)
        {
            _username = Environment.GetEnvironmentVariable("hue-username");
            _baseURL = Environment.GetEnvironmentVariable("hue-url");
            _client = client;
        }

        public async Task<Dictionary<string, Group>> GetAllGroups()
        {
            string url = _baseURL + _username + "/groups";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            string stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, Group>>(stringResponse);

            return result;
        }

        public async Task<Dictionary<string, Scene>> GetAllScenes()
        {
            string url = _baseURL + _username + "/scenes";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            string stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, Scene>>(stringResponse);

            return result;
        }

        public async Task<HttpStatusCode> SetScene(int id, string sceneId)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> TurnOff(int id)
        {
            string url = _baseURL + _username + $"/lights/{id}/state";
            HttpContent content = new StringContent("{\"on\":false}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> TurnOn(int id)
        {
            string url = _baseURL + _username + $"/lights/{id}/state";
            HttpContent content = new StringContent("{\"on\":true}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return response.StatusCode;
        }
    }
}
