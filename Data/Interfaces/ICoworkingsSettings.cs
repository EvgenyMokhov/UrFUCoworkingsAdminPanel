using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface ICoworkingsSettings
    {
        public Task<List<CoworkingSettings>> GetCoworkingSettingsAsync(Guid coworkingId);
        public Task<CoworkingSettings> GetCoworkingSettingAsync(Guid id);
        public Task UpdateCoworkingSettingsAsync(CoworkingSettings coworkingSettings);
        public Task DeleteCoworkingSettingsAsync(CoworkingSettings settings);
        public Task CreateCoworkingSettingsAsync(CoworkingSettings settings);
        public Task<List<CoworkingSettings>> GetAllSettings();
    }
}
