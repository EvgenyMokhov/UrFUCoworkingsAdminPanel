using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    public class UpdateSettingAnywayRequest
    {
        public Guid CoworkingId { get; set; }
        public CSEdit SettingData { get; set; }
    }
}
