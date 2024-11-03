using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("deleteCoworking-responses")]
    public class DeleteCoworkingResponse
    {
        public Guid Id { get; set; }
    }
}
