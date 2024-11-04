using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    [EntityName("update-zone-requests-queue")]
    public class UpdateZoneRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
        public ZoneEdit RequestData { get; set; }
    }
}
