using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    [EntityName("delete-zone-requests-queue")]
    public class DeleteZoneRequest
    {
        public Guid Id { get; set; }
        public int ZoneId { get; set; }
    }
}
