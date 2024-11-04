using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    [EntityName("create-zone-requests-queue")]
    public class CreateZoneRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
