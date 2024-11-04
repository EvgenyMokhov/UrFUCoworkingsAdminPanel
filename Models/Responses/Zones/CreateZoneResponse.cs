using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Zones
{
    [EntityName("create-zone-responses-queue")]
    public class CreateZoneResponse
    {
        public Guid Id { get; set; }
    }
}
