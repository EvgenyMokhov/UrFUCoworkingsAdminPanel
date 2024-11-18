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
        public async Task<List<CSEdit>> GetSettingsAsync([FromQuery] Guid coworkingId)
        {
            return await ServiceManager.CSService.GetSettingsAsync(coworkingId);
        }

        [HttpPost(Name = "CreateSetting")]
        public async Task CreateSettingAsync([FromQuery] Guid coworkingId)
        {
            await ServiceManager.CSService.CreateSettingAsync(coworkingId);
        }

        [HttpPut(Name = "SaveSettingAnyway")]
        public async Task<List<(Guid UserId, Guid ReservationId)>> UpdateSettingAsync([FromQuery] Guid coworkingId, [FromBody] CSEdit model)

        {
            return await ServiceManager.CSService.CSSaveAsync(coworkingId, model);
        }

        [HttpPut("{coworkingId}", Name = "TrySaveSetting")]
        public async Task<List<Guid>> TrySaveSettingAsync(Guid coworkingId, [FromBody] CSEdit model)
        {
            return await ServiceManager.CSService.TryCSSaveAsync(coworkingId, model);
        }

        [HttpDelete(Name = "DeleteSetting")]
        public async Task DeleteSettingAsync([FromQuery] Guid settingId)
        {
            await ServiceManager.CSService.DeleteSettingAsync(settingId);
        }
    }
}
