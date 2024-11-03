using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("getSettings-responses")]
    public class GetSettingsResponse
    {
        public Guid Id { get; set; }
        public List<CSEdit> ResponseData { get; set; }
    }
}
