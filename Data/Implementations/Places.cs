using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Places : IPlaces
    {
        private EFDBContext Context;
        public Places(EFDBContext context)
        {
            Context = context;
        }
        public IEnumerable<Place> GetAllPlaces()
        {
            return Context.Places;
        }

        public Place GetPlace(int id)
        {
            return Context.Places.FirstOrDefault(x => x.Id == id);
        }
    }
}
