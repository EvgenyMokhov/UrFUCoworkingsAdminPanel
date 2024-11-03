using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("getCoworkingById-responses")]
    public class GetCoworkingByIdResponse
    {
        public Guid Id { get; set; }
        public CoworkingEdit ResponseData { get; set; }
    }
}
