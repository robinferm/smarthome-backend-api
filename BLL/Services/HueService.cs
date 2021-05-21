using smarthome_backend_api.BLL.Models;
using smarthome_backend_api.BLL.Services.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace smarthome_backend_api.BLL.Services
{
    public class HueService : IHueService, IDisposable
    {
        static HttpClientHandler clientHandler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        };

        private readonly HttpClient _client = new HttpClient(clientHandler);

        public void Dispose()
        {
        }

        public async Task<Light> GetLights()
        {
            var username = Environment.GetEnvironmentVariable("hue-username");
            var baseurl = Environment.GetEnvironmentVariable("hue-url");
            var url = baseurl + username + "/lights/6";
            var result = new Light();
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();



                //result = JsonSerializer.Deserialize<List<Rootobject>>(stringResponse);
                //result = JObject.Parse(stringResponse);

                result = JsonSerializer.Deserialize<Light>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<LightState> TurnOn(int id)
        {
            var username = Environment.GetEnvironmentVariable("hue-username");
            var baseurl = Environment.GetEnvironmentVariable("hue-url");
            var url = baseurl + username + $"/lights/{id}/state";

            var result = new LightState();
            HttpContent test = new StringContent("{\"on\":false}", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(url, test);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();



                //result = JsonSerializer.Deserialize<List<Rootobject>>(stringResponse);
                //result = JObject.Parse(stringResponse);

                result = JsonSerializer.Deserialize<LightState>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
