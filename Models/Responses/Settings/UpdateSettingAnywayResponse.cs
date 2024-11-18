using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    public class UpdateSettingAnywayResponse
    {
        public List<(Guid UserId, Guid ReservationId)> ResponseData { get; set; }
    }
}
