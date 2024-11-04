using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("get-coworkings-responses-queue")]
    public class GetCoworkingsResponse
    {
        public Guid Id { get; set; }
        public List<CoworkingView> ResponseData { get; set; }
    }
}
