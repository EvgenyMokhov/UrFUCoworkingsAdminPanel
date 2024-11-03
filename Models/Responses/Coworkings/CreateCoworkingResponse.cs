using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("createCoworking-responses")]
    public class CreateCoworkingResponse
    {
        public Guid Id { get; set; }
        public int ResponseData { get; set; }
    }
}
