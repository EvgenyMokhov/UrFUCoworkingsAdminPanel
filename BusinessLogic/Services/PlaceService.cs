using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class PlaceService
    {
        private readonly IServiceProvider serviceProvider;
        public PlaceService(IServiceProvider provider) => serviceProvider = provider;

        public async Task<Place> CreatePlaceAsync(int zoneId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
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
