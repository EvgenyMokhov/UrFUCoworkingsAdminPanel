using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("get-settings-requests-queue")]
    public class GetSettingsRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
