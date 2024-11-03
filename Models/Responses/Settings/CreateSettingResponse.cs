using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("createSetting-responses")]
    public class CreateSettingResponse
    {
        public Guid Id { get; set; }
    }
}
