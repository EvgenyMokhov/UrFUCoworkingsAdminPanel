using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("getCoworkingById-requests")]
    public class GetCoworkingByIdRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
