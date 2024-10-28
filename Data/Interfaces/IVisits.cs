using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IVisits
    {
        public IEnumerable<Visit> GetAllVisits();
        public Visit GetVisit(Guid guid);
        public Visit GetVisit(int userId, int reservationId);
        public void UpdateVisit(Visit visit);
        public Task<List<Visit>> GetVisitsByReservationIdAsync(int reservationId);
    }
}
