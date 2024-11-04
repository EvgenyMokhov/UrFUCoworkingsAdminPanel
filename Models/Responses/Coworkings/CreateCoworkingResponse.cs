using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("create-coworking-responses-queue")]
    public class CreateCoworkingResponse
    {
        public Guid Id { get; set; }
        public int ResponseData { get; set; }
    }
}
