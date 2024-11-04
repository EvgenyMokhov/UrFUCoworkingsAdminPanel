using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Settings
{
    [EntityName("delete-setting-requests-queue")]
    public class DeleteSettingRequest
    {
        public Guid Id { get; set; }
        public int SettingId { get; set; }
    }
}
