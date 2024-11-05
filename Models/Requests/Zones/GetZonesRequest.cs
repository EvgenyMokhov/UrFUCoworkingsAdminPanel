using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    public class GetZonesRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
