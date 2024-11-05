using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    public class DeleteSettingRequest
    {
        public Guid Id { get; set; }
        public int SettingId { get; set; }
    }
}
