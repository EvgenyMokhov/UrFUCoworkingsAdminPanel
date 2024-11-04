using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("create-coworking-requests-queue")]
    public class CreateCoworkingRequest
    {
        public Guid Id { get; set; }
    }
}
