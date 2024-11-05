using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Zones
{
    public class GetZonesResponse
    {
        public List<ZoneEdit> ResponseData { get; set; }
    }
}
