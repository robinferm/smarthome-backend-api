using smarthome_backend_api.BLL.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace smarthome_backend_api.BLL.Services.Interfaces
{
    public interface IHueService
    {
        public Task<Dictionary<string, Scene>> GetAllScenes();
        public Task<HttpStatusCode> TurnOn(int id);
        public Task<HttpStatusCode> TurnOff(int id);
    }
}