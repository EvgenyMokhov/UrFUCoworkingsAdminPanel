using MassTransit;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Coworkings
{
    public class GetCoworkingByIdResponse
    {
        public CoworkingEdit ResponseData { get; set; }
    }
}
