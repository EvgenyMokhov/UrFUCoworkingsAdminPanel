using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("create-setting-responses-queue")]
    public class CreateSettingResponse
    {
        public Guid Id { get; set; }
    }
}
