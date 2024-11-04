using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("delete-setting-responses-queue")]
    public class DeleteSettingResponse
    {
        public Guid Id { get; set; }
    }
}
