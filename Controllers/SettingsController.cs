using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ServiceManager ServiceManager;
        public SettingsController(IServiceProvider provider) => ServiceManager = new(provider);

        [HttpGet(Name = "GetSettings")]
        public async Task<List<CSEdit>> GetSettingsAsync([FromQuery] int coworkingId)
        {
            return await ServiceManager.CSService.GetSettingsAsync(coworkingId);
        }

        [HttpPost(Name = "CreateSetting")]
        public async Task CreateSettingAsync([FromQuery] int coworkingId)
        {
            await ServiceManager.CSService.CreateSettingAsync(coworkingId);
        }

        [HttpPut(Name = "SaveSettingAnyway")]
        public async Task<List<(int UserId, int ReservationId)>> UpdateSettingAsync([FromQuery] int coworkingId, [FromBody] CSEdit model)

        {
            return await ServiceManager.CSService.CSSaveAsync(coworkingId, model);
        }

        [HttpPut("{coworkingId}", Name = "TrySaveSetting")]
        public async Task<List<int>> TrySaveSettingAsync(int coworkingId, [FromBody] CSEdit model)
        {
            return await ServiceManager.CSService.TryCSSaveAsync(coworkingId, model);
        }

        [HttpDelete(Name = "DeleteSetting")]
        public async Task DeleteSettingAsync([FromQuery] int settingId)
        {
            await ServiceManager.CSService.DeleteSettingAsync(settingId);
        }
    }
}
