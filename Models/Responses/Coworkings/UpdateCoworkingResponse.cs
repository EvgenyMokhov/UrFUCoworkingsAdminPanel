using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("update-coworking-responses-queue")]
    public class UpdateCoworkingResponse
    {
        public Guid Id { get; set; }
    }
}
