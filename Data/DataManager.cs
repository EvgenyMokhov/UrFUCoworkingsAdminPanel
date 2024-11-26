using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data
{
    public class DataManager
    {
        public IUsers Users { get; set; }
        public IVisits Visits { get; set; }
        public IReservations Reservations { get; set; }
        public IPlaces Places { get; set; }
        public IZones Zones { get; set; }
        public ICoworkings Coworkings { get; set; }
        public ICoworkingsSettings CoworkingsSettings { get; set; }
        public DataManager(IPlaces places, IVisits visits, IReservations reservations, IUsers users, IZones zones, ICoworkings coworkings, ICoworkingsSettings coworkingsSettings)
        {
            Places = places;
            Visits = visits;
            Reservations = reservations;
            Users = users;
            Zones = zones;
            Coworkings = coworkings;
            CoworkingsSettings = coworkingsSettings;
        }
    }
}
