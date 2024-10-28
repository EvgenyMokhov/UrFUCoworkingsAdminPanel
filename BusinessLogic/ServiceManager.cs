using UrFUCoworkingsAdminPanel.BusinessLogic.Services;
using UrFUCoworkingsAdminPanel.Data;

namespace UrFUCoworkingsAdminPanel.BusinessLogic
{
    public class ServiceManager
    {
        public CoworkingService CoworkingService { get; set; }
        public ZoneService ZoneService { get; set; }
        public CSService CSService { get; set; }
        public ServiceManager(DataManager dataManager) 
        {
            CoworkingService = new(dataManager);
            ZoneService = new(dataManager);
            CSService = new(dataManager);
        }
    }
}
