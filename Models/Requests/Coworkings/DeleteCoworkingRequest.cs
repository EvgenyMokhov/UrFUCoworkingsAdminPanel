using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    public class DeleteCoworkingRequest
    {
        public Guid CoworkingId { get; set; }
    }
}
