using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Visitors : IVisitors
    {
        private EFDBContext Context;
        public Visitors(EFDBContext context)
        {
            Context = context;
        }

        public IEnumerable<Visitor> GetAllVisitors()
        {
            return Context.Visitors;
        }

        public Visitor GetVisitor(Guid guid)
        {
            return Context.Visitors.FirstOrDefault(x => x.Id == guid);
        }

        public Visitor GetVisitor(int userId, int reservationId)
        {
            return Context.Visitors.FirstOrDefault(x => x.UserId == userId && x.ReservationId == reservationId);
        }

        public void UpdateVisitor(Visitor visitor)
        {
            Context.Visitors.Add(visitor);
            Context.SaveChanges();
        }

        public IEnumerable<Visitor> GetVisitsByReservationId(int reservationId)
        {
            return Context.Visitors.Where(visit => visit.ReservationId == reservationId);
        }
    }
}
