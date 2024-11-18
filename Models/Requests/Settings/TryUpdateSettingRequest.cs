using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    public class TryUpdateSettingRequest
    {
        public Guid CoworkingId { get; set; }
        public CSEdit SettingData { get; set; }
    }
}
