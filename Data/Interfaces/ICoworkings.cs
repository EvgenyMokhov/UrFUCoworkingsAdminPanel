using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface ICoworkings
    {
        public Task<IEnumerable<Coworking>> GetCoworkingsAsync();
        public Coworking GetCoworking(int id);
        public Task UpdateCoworkingAsync(Coworking coworking);
        public void DeleteCoworking(int id);
    }
}
