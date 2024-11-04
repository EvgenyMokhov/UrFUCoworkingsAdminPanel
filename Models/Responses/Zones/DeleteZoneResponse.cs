using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Zones
{
    [EntityName("delete-zone-responses-queue")]
    public class DeleteZoneResponse
    {
        public Guid Id { get; set; }
    }
}
