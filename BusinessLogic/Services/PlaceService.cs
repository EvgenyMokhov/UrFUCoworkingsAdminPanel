using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class PlaceService
    {
        private readonly DataManager dataManager;
        public PlaceService(DataManager dataManager) => this.dataManager = dataManager;

        public async Task<Place> CreatePlaceAsync(int zoneId)
        {
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
