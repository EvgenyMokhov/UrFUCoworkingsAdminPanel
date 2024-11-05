using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    public class UpdateZoneRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
        public ZoneEdit RequestData { get; set; }
    }
}
