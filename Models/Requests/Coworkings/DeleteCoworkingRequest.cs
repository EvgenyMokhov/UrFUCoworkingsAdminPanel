using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("delete-coworking-requests-queue")]
    public class DeleteCoworkingRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
