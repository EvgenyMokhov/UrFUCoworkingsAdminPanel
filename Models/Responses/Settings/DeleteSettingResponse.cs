using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("deleteSetting-responses")]
    public class DeleteSettingResponse
    {
        public Guid Id { get; set; }
    }
}
