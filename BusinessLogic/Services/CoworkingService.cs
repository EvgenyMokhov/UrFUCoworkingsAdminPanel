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
            Coworking coworking = new();
            coworking.Id = editModel.Id;
            coworking.Name = editModel.Name;
            coworking.Zones = new();
            coworking.Settings = new();
            await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
        }

        public async Task<List<CoworkingView>> GetCoworkingsAsync()
        {
            IEnumerable<Coworking> data = await dataManager.Coworkings.GetCoworkingsAsync();
            return data.Select(CoworkingDbToView).ToList();
        }

        public async Task<CoworkingEdit> GetCoworking(int id)
        {
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(id);
            CoworkingEdit editModel = new();
            editModel.Id = id;
            editModel.Name = coworking.Name;
            editModel.Zones = new();
            editModel.Settings = new();
            ZoneService zoneService = new(dataManager);
            CSService csService = new(dataManager);
            foreach (Zone zone in coworking.Zones)
                editModel.Zones.Add(zoneService.DbZoneToEdit(zone));
            foreach (CoworkingSettings cs in coworking.Settings)
                editModel.Settings.Add(csService.DbCSToEdit(cs));
            return editModel;
        }

        private CoworkingView CoworkingDbToView(Coworking coworking)
        {
            CoworkingView viewModel = new();
            viewModel.Id = coworking.Id;
            viewModel.Name = coworking.Name;
            viewModel.Zones = coworking.Zones.Select(zone => new ZoneView() { Id = zone.Id, Places = zone.Places.Select(place => new PlaceView() { Id = place.Id }).ToList() }).ToList();
            return viewModel;
        }

    }
}
