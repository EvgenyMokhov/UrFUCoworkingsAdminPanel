using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface ICoworkingsSettings
    {
        public IEnumerable<CoworkingSettings> GetCoworkingSettings();
        public CoworkingSettings GetCoworkingSettings(int id);
        public void UpdateCoworkingSettings(CoworkingSettings coworkingSettings);
        public void DeleteCoworkingSettings(int id);
    }
}
