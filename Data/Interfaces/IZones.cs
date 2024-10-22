using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IZones
    {
        public IEnumerable<Zone> GetZones();
        public Task<Zone> GetZoneAsync(int zoneId);
        public Task UpdateZoneAsync(Zone zone);
        public Task DeleteZoneAsync(int zoneId);
        public Task<List<Zone>> GetZonesWithCoworkingIdAsync(int coworkingId);
    }
}
