using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class CSService
    {
        private readonly DataManager dataManager;
        public CSService(DataManager dataManager) => this.dataManager = dataManager;
        public CSEdit DbCSToEdit(CoworkingSettings settings)
        {
            return new(){ Id = settings.Id, Day = settings.Day, Opening = settings.Opening, Closing = settings.Closing, IsWorking = settings.IsWorking };
        }
    }
}
