using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("try-update-setting-requests-queue")]
    public class TryUpdateSettingRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
        public CSEdit SettingData { get; set; }
    }
}
