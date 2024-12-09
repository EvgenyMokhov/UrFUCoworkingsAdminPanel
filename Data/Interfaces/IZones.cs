using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IZones
    {
        public IEnumerable<Zone> GetZones();
        public Task<Zone> GetZoneAsync(Guid zoneId);
        public Task UpdateZoneAsync(Zone zone);
        public Task DeleteZoneAsync(Zone zone);
        public Task CreateZoneAsync(Zone zone);
        public Task<List<Zone>> GetZonesWithCoworkingIdAsync(Guid coworkingId);
    }
}
