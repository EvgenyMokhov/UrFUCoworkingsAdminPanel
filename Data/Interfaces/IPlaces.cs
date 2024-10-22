using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IPlaces
    {
        public IEnumerable<Place> GetAllPlaces();
        public Place GetPlace(int id);
        public void DeletePlace(int id);
        public Task UpdatePlaceAsync(Place place);
    }
}
