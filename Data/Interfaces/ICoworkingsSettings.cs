using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface ICoworkingsSettings
    {
        public Task<List<CoworkingSettings>> GetCoworkingSettingsAsync(int coworkingId);
        public Task<CoworkingSettings> GetCoworkingSettingAsync(int id);
        public Task UpdateCoworkingSettingsAsync(CoworkingSettings coworkingSettings);
        public Task DeleteCoworkingSettingsAsync(int id);
    }
}
