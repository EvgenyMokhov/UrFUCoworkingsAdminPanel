using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    public class CreateSettingRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
