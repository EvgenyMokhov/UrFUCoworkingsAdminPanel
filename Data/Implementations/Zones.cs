using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsModels.Data;
using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    public class Zones : IZones
    {
        private readonly EFDBContext Context;
        public Zones(EFDBContext context) => Context = context;
        public async Task DeleteZoneAsync(Zone zone)
        {
            Context.Zones.Remove(zone);
            await Context.SaveChangesAsync();
        }

        public async Task<Zone> GetZoneAsync(Guid id)
        {
            return await Context.Zones.FirstOrDefaultAsync(z => z.Id == id);
        }

        public IEnumerable<Zone> GetZones()
        {
            return Context.Zones;
        }

        public async Task UpdateZoneAsync(Zone zone)
        {
            Context.Entry(zone).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task<List<Zone>> GetZonesWithCoworkingIdAsync(Guid coworkingId)
        {
            return await Context.Zones.Where(zone => zone.CoworkingId == coworkingId).ToListAsync();
        }

        public async Task CreateZoneAsync(Zone zone)
        {
            await Context.Zones.AddAsync(zone);
            await Context.SaveChangesAsync();
        }
    }
}
