using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Zones
{
    [EntityName("get-zones-responses-queue")]
    public class GetZonesResponse
    {
        public Guid Id { get; set; }
        public List<ZoneEdit> ResponseData { get; set; }
    }
}
