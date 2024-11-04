using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Zones
{
    [EntityName("update-zone-responses-queue")]
    public class UpdateZoneResponse
    {
        public Guid Id {  get; set; }
    }
}
