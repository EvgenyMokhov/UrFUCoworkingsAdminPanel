using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("create-setting-requests-queue")]
    public class CreateSettingRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
