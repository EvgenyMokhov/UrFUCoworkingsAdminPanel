using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    public class UpdateSettingAnywayResponse
    {
        public List<(int UserId, int ReservationId)> ResponseData { get; set; }
    }
}
