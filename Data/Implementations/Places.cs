using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsModels.Data;
using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Places : IPlaces
    {
        private readonly EFDBContext Context;
        public Places(EFDBContext context) => Context = context;

        public async Task DeletePlaceAsync(Place place)
        {
            Context.Places.Remove(place);
            await Context.SaveChangesAsync();
        }

        public async Task<Place> GetPlaceAsync(Guid id)
        {
            return await Context.Places.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdatePlaceAsync(Place place)
        {
            Context.Entry(place).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task CreatePlaceAsync(Place place)
        {
            await Context.Places.AddAsync(place);
            await Context.SaveChangesAsync();
        }
    }
}
