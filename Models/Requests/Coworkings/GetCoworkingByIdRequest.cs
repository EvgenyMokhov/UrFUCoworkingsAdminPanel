using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    public class GetCoworkingByIdRequest
    {
        public Guid CoworkingId { get; set; }
    }
}
