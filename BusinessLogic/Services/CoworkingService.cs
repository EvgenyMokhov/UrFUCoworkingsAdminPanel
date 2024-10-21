using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class CoworkingService
    {
        private readonly DataManager dataManager;
        public CoworkingService(DataManager dataManager) => this.dataManager = dataManager;
        public async Task CreateCoworkingAsync(CoworkingEdit editModel)
        {
            Coworking coworking = CoworkingEditToDb(editModel);
            await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
        }

        public async Task<List<CoworkingView>> GetCoworkingsAsync()
        {
            IEnumerable<Coworking> data = await dataManager.Coworkings.GetCoworkingsAsync();
            return data.Select(CoworkingDbToView).ToList();
        }

        private CoworkingView CoworkingDbToView(Coworking coworking)
        {
            CoworkingView viewModel = new();
            viewModel.Id = coworking.Id;
            viewModel.Name = coworking.Name;
            viewModel.Zones = coworking.Zones.Select(zone => new ZoneView() { Id = zone.Id, Places = zone.Places.Select(place => new PlaceView() { Id = place.Id }).ToList() }).ToList();
            return viewModel;
        }

        private Coworking CoworkingEditToDb(CoworkingEdit editModel)
        {
            return new();
        }
    }
}
