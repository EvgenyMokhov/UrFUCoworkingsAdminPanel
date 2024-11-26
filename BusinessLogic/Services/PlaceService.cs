using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsModels.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class PlaceService
    {
        private readonly IServiceProvider serviceProvider;
        public PlaceService(IServiceProvider provider) => serviceProvider = provider;

        public async Task<Place> CreatePlaceAsync(Guid zoneId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            Place place = new() {Id = Guid.NewGuid(), Zone = await dataManager.Zones.GetZoneAsync(zoneId) };
            await dataManager.Places.CreatePlaceAsync(place);
            return place;
        }
        public PlaceEdit DbPlaceToEdit(Place place)
        {
            return new() { Id = place.Id };
        }
    }
}
