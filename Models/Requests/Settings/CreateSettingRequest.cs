using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    public class CreateSettingRequest
    {
        public Guid CoworkingId { get; set; }
    }
}
