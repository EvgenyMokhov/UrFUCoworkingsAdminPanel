using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data
{
    public class DataManagerFactory
    {
        private readonly IServiceProvider provider;
        public DataManagerFactory(IServiceProvider provider) => this.provider = provider;
        public DataManager Create()
        {
            return new DataManager(
                provider.GetRequiredService<IPlaces>(), 
                provider.GetRequiredService<IVisits>(), 
                provider.GetRequiredService<IReservations>(), 
                provider.GetRequiredService<IUsers>(), 
                provider.GetRequiredService<IZones>(), 
                provider.GetRequiredService<ICoworkings>(), 
                provider.GetRequiredService<ICoworkingsSettings>()
            );
        }
    }
}
