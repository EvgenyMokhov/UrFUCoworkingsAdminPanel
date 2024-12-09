using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data
{
    public class DataManager
    {
        public IReservations Reservations { get; set; }
        public IPlaces Places { get; set; }
        public IZones Zones { get; set; }
        public ICoworkings Coworkings { get; set; }
        public ICoworkingsSettings CoworkingsSettings { get; set; }
        public DataManager(IPlaces places, IReservations reservations, IZones zones, ICoworkings coworkings, ICoworkingsSettings coworkingsSettings)
        {
            Places = places;
            Reservations = reservations;
            Zones = zones;
            Coworkings = coworkings;
            CoworkingsSettings = coworkingsSettings;
        }
    }
}
