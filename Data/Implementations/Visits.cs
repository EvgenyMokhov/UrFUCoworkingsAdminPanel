using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Visits : IVisits
    {
        private readonly EFDBContext Context;
        public Visits(EFDBContext context) => Context = context;

        public IEnumerable<Visit> GetAllVisits()
        {
            return Context.Visits;
        }

        public Visit GetVisit(Guid guid)
        {
            return Context.Visits.FirstOrDefault(x => x.Id == guid);
        }

        public Visit GetVisit(Guid userId, Guid reservationId)
        {
            return Context.Visits.FirstOrDefault(x => x.UserId == userId && x.ReservationId == reservationId);
        }

        public void UpdateVisit(Visit visit)
        {
            Context.Visits.Add(visit);
            Context.SaveChanges();
        }

        public async Task<List<Visit>> GetVisitsByReservationIdAsync(Guid reservationId)
        {
            return await Context.Visits.Where(visit => visit.ReservationId == reservationId).ToListAsync();
        }
    }
}
