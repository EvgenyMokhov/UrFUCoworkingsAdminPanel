using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IReservations
    {
        public IEnumerable<Reservation> GetAllReservations();
        public Task<Reservation> GetReservationAsync(int id);
        public Task UpdateReservationAsync(Reservation reservation);
        public Task DeleteReservationAsync(int id);
        public Task<List<Reservation>> GetReservationsOnDateAsync(DateOnly date);
    }
}
