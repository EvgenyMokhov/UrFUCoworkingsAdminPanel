using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IZones
    {
        public IEnumerable<Zone> GetZones();
        public Zone GetZone(int zoneId);
        public void UpdateZone(Zone zone);
        public void DeleteZone(int zoneId);
    }
}
