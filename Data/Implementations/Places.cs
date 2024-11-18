using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Places : IPlaces
    {
        private readonly EFDBContext Context;
        public Places(EFDBContext context) => Context = context;

        public void DeletePlace(Guid id)
        {
            Context.Places.Remove(GetPlace(id));
            Context.SaveChanges();
        }

        public IEnumerable<Place> GetAllPlaces()
        {
            return Context.Places;
        }

        public Place GetPlace(Guid id)
        {
            return Context.Places.FirstOrDefault(x => x.Id == id);
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
