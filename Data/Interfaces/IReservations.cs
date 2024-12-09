using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IReservations
    {
        public Task DeleteReservationAsync(Reservation reservation);
        public Task<List<Reservation>> GetReservationsOnDateAsync(DateOnly date);
        public Task<List<Reservation>> GetReservationsOnPlacesAsync(List<Place> places);

    }
}
