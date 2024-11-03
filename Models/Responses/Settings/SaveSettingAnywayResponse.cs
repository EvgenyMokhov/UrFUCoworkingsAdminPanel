using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("saveSettingAnyway-responses")]
    public class SaveSettingAnywayResponse
    {
        public Guid Id { get; set; }
        public List<(int UserId, int ReservationId)> ResponseData { get; set; }
    }
}
