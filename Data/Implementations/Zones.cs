using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    public class Zones : IZones
    {
        private readonly EFDBContext Context;
        public Zones(EFDBContext context) => Context = context;
        public async Task DeleteZoneAsync(int id)
        {
            Context.Zones.Remove(await Context.Zones.FirstOrDefaultAsync(z => z.Id == id));
            await Context.SaveChangesAsync();
        }

        public async Task<Zone> GetZoneAsync(int id)
        {
            return await Context.Zones.FirstOrDefaultAsync(z => z.Id == id);
        }

        public IEnumerable<Zone> GetZones()
        {
            return Context.Zones;
        }

        public async Task UpdateZoneAsync(Zone zone)
        {
            if (zone.Id == 0)
                await Context.Zones.AddAsync(zone);
            else
                Context.Entry(zone).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task<List<Zone>> GetZonesWithCoworkingIdAsync(int coworkingId)
        {
            return await Context.Zones.Where(zone => zone.CoworkingId == coworkingId).ToListAsync();
        }
    }
}
