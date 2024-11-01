using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class PlaceService
    {
        private readonly DataManagerFactory DMFactory;
        private readonly IServiceProvider serviceProvider;
        public PlaceService(IServiceProvider provider)
        {
            DMFactory = new DataManagerFactory(provider);
            serviceProvider = provider;
        }

        public async Task<Place> CreatePlaceAsync(int zoneId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManagerFactory DMFactory = new(serviceProvider);
            DataManager dataManager = DMFactory.Create();
            Place place = new() { Zone = await dataManager.Zones.GetZoneAsync(zoneId) };
            await dataManager.Places.UpdatePlaceAsync(place);
            return place;
        }
        public PlaceEdit DbPlaceToEdit(Place place)
        {
            return new() { Id = place.Id };
        }
    }
}
