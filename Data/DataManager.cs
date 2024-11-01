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
        public DataManager(IServiceProvider provider)
        {
            Places = provider.GetRequiredService<IPlaces>();
            Visits = provider.GetRequiredService<IVisits>();
            Reservations = provider.GetRequiredService<IReservations>();
            Users = provider.GetRequiredService<IUsers>();
            Zones = provider.GetRequiredService<IZones>();
            Coworkings = provider.GetRequiredService<ICoworkings>();
            CoworkingsSettings = provider.GetRequiredService<ICoworkingsSettings>();
        }
    }
}
