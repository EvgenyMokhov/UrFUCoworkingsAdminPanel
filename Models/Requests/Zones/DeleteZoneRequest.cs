using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    public class DeleteZoneRequest
    {
        public Guid Id { get; set; }
        public int ZoneId { get; set; }
    }
}
