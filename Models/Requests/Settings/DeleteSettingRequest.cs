using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("deleteSetting-requests")]
    public class DeleteSettingRequest
    {
        public Guid Id { get; set; }
        public int SettingId { get; set; }
    }
}
