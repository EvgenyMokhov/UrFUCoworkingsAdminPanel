using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Reservations : IReservations
    {
        private readonly EFDBContext Context;
        public Reservations(EFDBContext context) => Context = context;
        public async Task DeleteReservationAsync(int id)
        {
            Context.Reservations.Remove(await Context.Reservations.FirstOrDefaultAsync(x => x.Id == id));
            await Context.SaveChangesAsync();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return Context.Reservations;
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            return await Context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            if (reservation.Id == 0)
                await Context.Reservations.AddAsync(reservation);
            else
                Context.Entry(reservation).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetReservationsOnDateAsync(DateOnly date)
        {
            return await Context.Reservations.Where(res => DateOnly.FromDateTime(res.ReservationBegin) == date).ToListAsync();
        }
    }
}
