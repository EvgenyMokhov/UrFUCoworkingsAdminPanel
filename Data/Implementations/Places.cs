using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Places : IPlaces
    {
        private readonly EFDBContext Context;
        public Places(EFDBContext context) => Context = context;

        public void DeletePlace(int id)
        {
            Context.Places.Remove(GetPlace(id));
            Context.SaveChanges();
        }

        public IEnumerable<Place> GetAllPlaces()
        {
            return Context.Places;
        }

        public Place GetPlace(int id)
        {
            return Context.Places.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdatePlaceAsync(Place place)
        {
            if (place.Id == 0)
                await Context.Places.AddAsync(place);
            else
                Context.Entry(place).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
