using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Requests.Coworkings
{
    [EntityName("createCoworking-requests")]
    public class CreateCoworkingRequest
    {
        public Guid Id { get; set; }
    }
}
