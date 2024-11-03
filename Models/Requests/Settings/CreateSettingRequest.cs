using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("createSetting-requests")]
    public class CreateSettingRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
