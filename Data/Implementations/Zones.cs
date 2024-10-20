using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    public class Zones : IZones
    {
        private readonly EFDBContext Context;
        public Zones(EFDBContext context) => Context = context;
        public void DeleteZone(int id)
        {
            Context.Zones.Remove(GetZone(id));
            Context.SaveChanges();
        }

        public Zone GetZone(int id)
        {
            return Context.Zones.FirstOrDefault(z => z.Id == id);
        }

        public IEnumerable<Zone> GetZones()
        {
            return Context.Zones;
        }

        public void UpdateZone(Zone zone)
        {
            if (zone.Id == 0)
                Context.Zones.Add(zone);
            else
                Context.Entry(zone).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
