using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface ICoworkings
    {
        public Task<IEnumerable<Coworking>> GetCoworkingsAsync();
        public Task<Coworking> GetCoworkingAsync(Guid id);
        public Task UpdateCoworkingAsync(Coworking coworking);
        public Task CreateCoworkingAsync(Coworking coworking);
        public Task DeleteCoworking(Guid id);
    }
}
