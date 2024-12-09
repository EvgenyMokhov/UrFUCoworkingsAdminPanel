using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IPlaces
    {
        public Task UpdatePlaceAsync(Place place);
        public Task CreatePlaceAsync(Place place);
        public Task<Place> GetPlaceAsync(Guid placeId);
        public Task DeletePlaceAsync(Place place);
    }
}
