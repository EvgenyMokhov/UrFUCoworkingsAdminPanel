using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("get-coworking-by-id-responses-queue")]
    public class GetCoworkingByIdResponse
    {
        public Guid Id { get; set; }
        public CoworkingEdit ResponseData { get; set; }
    }
}
