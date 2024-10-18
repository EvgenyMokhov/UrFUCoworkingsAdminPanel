using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IVisitors
    {
        public IEnumerable<Visitor> GetAllVisitors();
        public Visitor GetVisitor(Guid guid);
        public Visitor GetVisitor(int userId, int reservationId);
        public void UpdateVisitor(Visitor visitor);
        public IEnumerable<Visitor> GetVisitsByReservationId(int reservationId);
    }
}
