using Microsoft.AspNetCore.Mvc;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly ServiceManager ServiceManager;
        public ZonesController(IServiceProvider provider) => ServiceManager = new(provider);

        [HttpGet(Name = "GetZones")]
        public async Task<List<ZoneEdit>> GetZonesAsync([FromQuery] int coworkingId)
        {
            return await ServiceManager.ZoneService.GetZonesAsync(coworkingId);
        }

        [HttpPost(Name = "CreateZone")]
        public async Task CreateZoneAsync([FromQuery] int coworkingId)
        {
            await ServiceManager.ZoneService.CreateZoneAsync(coworkingId);
        }

        [HttpPut(Name = "UpdateZone")]
        public async Task UpdateZoneAsync([FromQuery] int coworkingId, [FromBody] ZoneEdit editModel)
        {
            await ServiceManager.ZoneService.UpdateZoneAsync(coworkingId, editModel);
        }

        [HttpDelete(Name = "DeleteZone")]
        public async Task DeleteZoneAsync([FromQuery] int zoneId)
        {
            await ServiceManager.ZoneService.DeleteZoneAsync(zoneId);
        }
    }
}
