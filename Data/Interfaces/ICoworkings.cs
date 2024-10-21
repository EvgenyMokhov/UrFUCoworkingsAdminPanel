using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface ICoworkings
    {
        public Task<IEnumerable<Coworking>> GetCoworkingsAsync();
        public Task<Coworking> GetCoworkingAsync(int id);
        public Task UpdateCoworkingAsync(Coworking coworking);
        public Task DeleteCoworking(int id);
    }
}
