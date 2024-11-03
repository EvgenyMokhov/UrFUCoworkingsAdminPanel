using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("getSettings-requests")]
    public class GetSettingsRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
