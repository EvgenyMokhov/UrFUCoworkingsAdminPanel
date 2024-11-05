using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    public class GetSettingsResponse
    {
        public List<CSEdit> ResponseData { get; set; }
    }
}
