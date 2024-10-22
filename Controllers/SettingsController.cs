using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [HttpGet(Name = "GetSettings")]
        public async Task<List<CSEdit>> GetSettingsAsync([FromQuery] int coworkingId)
        {
            return new();
        }

        [HttpPost(Name = "CreateSetting")]
        public async Task CreateSettingAsync([FromQuery] int coworkingId, [FromBody] CSEdit model)
        {

        }

        [HttpPut(Name = "UpdateSetting")]
        public async Task UpdateSettingAsync([FromQuery] int coworkingId, [FromBody] CSEdit model)
        {

        }

        [HttpDelete(Name = "DeleteSettingAnyway")]
        public async Task DeleteSettingAsync([FromQuery] int coworkingId, [FromQuery] int settingId)
        {

        }

        [HttpDelete("{settingId}", Name = "TryDeleteSetting")]
        public async Task<bool> TryDeleteSettingAsync([FromQuery] int coworkingId, int settingId)
        {
            return true;
        }
    }
}
