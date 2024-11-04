using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("update-coworking-requests-queue")]
    public class UpdateCoworkingRequest
    {
        public Guid Id { get; set; }
        public CoworkingEdit RequestData { get; set; }
    }
}
