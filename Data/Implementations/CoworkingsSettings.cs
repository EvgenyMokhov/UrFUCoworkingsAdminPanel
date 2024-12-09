using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsModels.Data;
using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    public class CoworkingsSettings : ICoworkingsSettings
    {
        private readonly EFDBContext Context;
        public CoworkingsSettings(EFDBContext context) => Context = context;
        public async Task DeleteCoworkingSettingsAsync(CoworkingSettings settings)
        {
            Context.CoworkingSettings.Remove(settings);
            await Context.SaveChangesAsync();
        }

        public async Task<List<CoworkingSettings>> GetCoworkingSettingsAsync(Guid coworkingId)
        {
            return await Context.CoworkingSettings.Where(s => s.CoworkingId == coworkingId).ToListAsync();
        }

        public async Task<CoworkingSettings> GetCoworkingSettingAsync(Guid id)
        {
            return await Context.CoworkingSettings.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCoworkingSettingsAsync(CoworkingSettings coworkingSettings)
        {
            Context.Entry(coworkingSettings).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task CreateCoworkingSettingsAsync(CoworkingSettings settings)
        {
            await Context.CoworkingSettings.AddAsync(settings);
            await Context.SaveChangesAsync();
        }

        public async Task<List<CoworkingSettings>> GetAllSettings()
        {
            return await Context.CoworkingSettings.ToListAsync();
        }
    }
}
