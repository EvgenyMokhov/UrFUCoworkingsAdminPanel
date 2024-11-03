using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("trySaveSetting-requests")]
    public class TrySaveSettingRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
        public CSEdit SettingData { get; set; }
    }
}
