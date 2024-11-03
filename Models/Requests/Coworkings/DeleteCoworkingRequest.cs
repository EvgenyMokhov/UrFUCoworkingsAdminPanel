using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("deleteCoworking-requests")]
    public class DeleteCoworkingRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
