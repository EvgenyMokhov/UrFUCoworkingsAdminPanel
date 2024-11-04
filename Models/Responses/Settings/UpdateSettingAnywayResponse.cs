using MassTransit;

namespace UrFUCoworkingsAdminPanel.Models.Responses.Settings
{
    [EntityName("update-setting-anyway-responses-queue")]
    public class UpdateSettingAnywayResponse
    {
        public Guid Id { get; set; }
        public List<(int UserId, int ReservationId)> ResponseData { get; set; }
    }
}
