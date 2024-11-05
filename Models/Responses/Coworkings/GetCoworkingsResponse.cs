using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    public class GetCoworkingsResponse
    {
        public List<CoworkingView> ResponseData { get; set; }
    }
}
