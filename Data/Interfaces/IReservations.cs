using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IReservations
    {
        public Task DeleteReservationAsync(Guid id);
        public Task<List<Reservation>> GetReservationsOnDateAsync(DateOnly date);
    }
}
