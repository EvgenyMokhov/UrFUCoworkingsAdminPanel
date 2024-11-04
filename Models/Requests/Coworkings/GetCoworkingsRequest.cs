using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("get-coworkings-requests-queue")]
    public class GetCoworkingsRequest
    {
        public Guid Id { get; set; }
    }
}
