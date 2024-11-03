using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("trySaveSetting-responses")]
    public class TrySaveSettingResponse
    {
        public Guid Id { get; set; }
        public List<int> ResponseData { get; set; }
    }
}
