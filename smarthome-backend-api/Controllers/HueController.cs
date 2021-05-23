using Microsoft.AspNetCore.Mvc;
using smarthome_backend_api.BLL.Models;
using smarthome_backend_api.BLL.Services;
using smarthome_backend_api.BLL.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace smarthome_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HueController : ControllerBase
    {
        private readonly IHueService _hueService;

        public HueController(IHueService hueService)
        {
            _hueService = hueService;
        }

        [HttpGet]
        [Route("scenes")]
        public async Task<Dictionary<string, Scene>> GetAllScenes()
        {
            return await _hueService.GetAllScenes();
        }

        [HttpPut]
        [Route("{id:int}/on")]
        public async Task<HttpStatusCode> TurnOn(int id)
        {
            return await _hueService.TurnOn(id);
        }

        [HttpPut]
        [Route("{id:int}/off")]
        public async Task<HttpStatusCode> TurnOff(int id)
        {
            return await _hueService.TurnOff(id);
        }
    }
}
