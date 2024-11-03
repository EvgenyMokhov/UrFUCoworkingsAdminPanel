using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("getCoworkings-requests")]
    public class GetCoworkingsRequest
    {
        public Guid Id { get; set; }
    }
}
