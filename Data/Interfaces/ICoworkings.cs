using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface ICoworkings
    {
        public IEnumerable<Coworking> GetCoworkings();
        public Coworking GetCoworking(int id);
        public void UpdateCoworking(Coworking coworking);
        public void DeleteCoworking(int id);
    }
}
