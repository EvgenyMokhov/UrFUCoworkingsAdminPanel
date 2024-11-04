using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("delete-coworking-responses-queue")]
    public class DeleteCoworkingResponse
    {
        public Guid Id { get; set; }
    }
}
