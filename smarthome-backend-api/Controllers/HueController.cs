using Microsoft.AspNetCore.Mvc;
using smarthome_backend_api.BLL.Models;
using smarthome_backend_api.BLL.Services;
using smarthome_backend_api.BLL.Services.Interfaces;
using System.Collections.Generic;
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
        [Route("GetAllScenes")]
        public async Task<Dictionary<string, Scene>> GetAllScenes()
        {
            return await _hueService.GetAllScenes();
        }

        [HttpPut]
        [Route("TurnOn")]
        public async Task<Light> TurnOn(int id)
        {
            return await _hueService.TurnOn(id);
        }

        [HttpPut]
        [Route("TurnOff")]
        public async Task<Light> TurnOff(int id)
        {
            return await _hueService.TurnOff(id);
        }
    }
}
