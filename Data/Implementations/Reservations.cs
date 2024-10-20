using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Reservations : IReservations
    {
        private readonly EFDBContext Context;
        public Reservations(EFDBContext context) => Context = context;
        public void DeleteReservation(int id)
        {
            Context.Reservations.Remove(GetReservation(id));
            Context.SaveChanges();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return Context.Reservations;
        }

        public Reservation GetReservation(int id)
        {
            return Context.Reservations.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateReservation(Reservation reservation)
        {
            if (reservation.Id == 0)
                Context.Reservations.Add(reservation);
            else
                Context.Entry(reservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Reservation> GetReservationsOnDate(Place place, DateOnly date)
        {
            return Context.Reservations.Where(res => DateOnly.FromDateTime(res.ReservationBegin).CompareTo(date) >= 0 && res.Places.Contains(place));
        }
    }
}
