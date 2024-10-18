using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data
{
    public class DataManager
    {
        public IUsers Users { get; set; }
        public IVisitors Visitors { get; set; }
        public IReservations Reservations { get; set; }
        public IPlaces Places { get; set; }
        public DataManager(IPlaces places, IVisitors visitors, IReservations reservations, IUsers users)
        {
            Places = places;
            Visitors = visitors;
            Users = users;
            Reservations = reservations;
        }
    }
}
