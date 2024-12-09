using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsModels.Data;
using UrFUCoworkingsModels.Data.Entities;


namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    public class Coworkings : ICoworkings
    {
        private readonly EFDBContext Context;
        public Coworkings(EFDBContext context) => Context = context;
        public async Task DeleteCoworkingAsync(Coworking coworking)
        {
            Context.Coworkings.Remove(coworking);
            await Context.SaveChangesAsync();
        }

        public async Task<Coworking> GetCoworkingAsync(Guid id)
        {
            return await Context.Coworkings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Coworking>> GetCoworkingsAsync()
        {
            return await Context.Coworkings.ToListAsync();
        }

        public async Task UpdateCoworkingAsync(Coworking coworking)
        {
            
            Context.Entry(coworking).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
        public async Task CreateCoworkingAsync(Coworking coworking)
        {
            await Context.Coworkings.AddAsync(coworking);
            await Context.SaveChangesAsync();
        }
    }
}
