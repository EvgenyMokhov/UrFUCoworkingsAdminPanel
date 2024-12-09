using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsModels.Data;
using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Reservations : IReservations
    {
        private readonly EFDBContext Context;
        public Reservations(EFDBContext context) => Context = context;
        public async Task DeleteReservationAsync(Reservation reservation)
        {
            Context.Reservations.Remove(reservation);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetReservationsOnDateAsync(DateOnly date)
        {
            return await Context.Reservations.Where(res => DateOnly.FromDateTime(res.ReservationBegin) == date).ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsOnPlacesAsync(List<Place> places)
        {
            string param = string.Join(", ", places.Select(place => $"'{place.Id}'"));
            if (param == "")
                return new();
            string sql = $"SELECT * FROM Reservations WHERE EXISTS (SELECT 1 FROM PlaceReservation WHERE PlaceReservation.ReservationsId = Reservations.Id AND PlaceReservation.PlacesId IN ({param}))";
            return await Context.Reservations.FromSqlRaw(sql).ToListAsync();
        }
    }
}
