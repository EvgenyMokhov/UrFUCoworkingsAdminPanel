using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IReservations
    {
        public IEnumerable<Reservation> GetAllReservations();
        public Reservation GetReservation(int id);
        public void UpdateReservation(Reservation reservation);
        public void DeleteReservation(int id);
        public IEnumerable<Reservation> GetReservationsOnDate(Place place, DateOnly date);
    }
}
