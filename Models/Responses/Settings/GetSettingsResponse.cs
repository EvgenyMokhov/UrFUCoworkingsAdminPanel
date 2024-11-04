using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("get-settings-responses-queue")]
    public class GetSettingsResponse
    {
        public Guid Id { get; set; }
        public List<CSEdit> ResponseData { get; set; }
    }
}
