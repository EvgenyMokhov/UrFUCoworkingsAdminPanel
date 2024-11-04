using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("update-setting-anyway-requests-queue")]
    public class UpdateSettingAnywayRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
        public CSEdit SettingData { get; set; }
    }
}
