using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    [EntityName("getCoworkings-responses")]
    public class GetCoworkingsResponse
    {
        public Guid Id { get; set; }
        public List<CoworkingView> ResponseData { get; set; }
    }
}
