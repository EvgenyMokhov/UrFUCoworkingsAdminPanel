using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    public class GetCoworkingByIdRequest
    {
        public Guid Id { get; set; }
        public int CoworkingId { get; set; }
    }
}
