using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("try-update-setting-responses-queue")]
    public class TryUpdateSettingResponse
    {
        public Guid Id { get; set; }
        public List<int> ResponseData { get; set; }
    }
}
