using Microsoft.AspNetCore.Mvc;
using smarthome_backend_api.BLL.Models;
using smarthome_backend_api.BLL.Services;
using System.Threading.Tasks;

namespace smarthome_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HueController : ControllerBase
    {
        [HttpGet]
        public async Task<Light> GetLights()
        {
            Light lights;
            using (HueService hue = new HueService())
            {
                lights = await hue.GetLights();
            }
            return lights;
        }

        [HttpPut]
        public async Task<LightState> TurnOn(int id)
        {
            using (HueService hue = new HueService())
            {
                return await hue.TurnOn(id);
            }
        }
    }
}
