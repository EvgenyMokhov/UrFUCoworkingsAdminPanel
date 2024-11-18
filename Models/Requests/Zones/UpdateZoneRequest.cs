using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Zones
{
    public class UpdateZoneRequest
    {
        public Guid CoworkingId { get; set; }
        public ZoneEdit RequestData { get; set; }
    }
}
