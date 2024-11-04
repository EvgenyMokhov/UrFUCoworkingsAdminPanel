using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    [EntityName("get-zones-requests-queue")]
    public class GetZonesRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
