using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        [HttpGet(Name = "GetZones")]
        public async Task<List<ZoneEdit>> GetZonesAsync([FromQuery] int coworkingId)
        {
            return new();
        }

        [HttpPost(Name = "CreateZone")]
        public async Task CreateZoneAsync([FromQuery] int coworkingId)
        {

        }

        [HttpPut(Name = "UpdateZone")]
        public async Task UpdateZoneAsync([FromQuery] int coworkingId)
        {

        }
    }
}
