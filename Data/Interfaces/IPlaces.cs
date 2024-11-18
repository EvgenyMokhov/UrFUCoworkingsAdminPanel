using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IPlaces
    {
        public Task UpdatePlaceAsync(Place place);
        public Task CreatePlaceAsync(Place place);
    }
}
