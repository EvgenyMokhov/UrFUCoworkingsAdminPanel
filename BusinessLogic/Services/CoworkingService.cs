using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsModels.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class CoworkingService
    {
        private readonly IServiceProvider serviceProvider;
        public CoworkingService(IServiceProvider provider) => serviceProvider = provider;
        public async Task CreateCoworkingAsync(CoworkingEdit editModel)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            Coworking coworking = new();
            coworking.Id = Guid.NewGuid();
            coworking.Name = editModel.Name;
            coworking.Opening = new TimeOnly(8, 30);
            coworking.Closing = new TimeOnly(17, 0);
            coworking.Zones = new();
            coworking.Settings = new();
            await dataManager.Coworkings.CreateCoworkingAsync(coworking);
        }

        public async Task<List<CoworkingView>> GetCoworkingsAsync()
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            IEnumerable<Coworking> data = await dataManager.Coworkings.GetCoworkingsAsync();
            return data.Select(CoworkingDbToView).ToList();
        }

        public async Task<CoworkingEdit> GetCoworkingAsync(Guid id)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(id);
            CoworkingEdit editModel = new();
            editModel.Id = id;
            editModel.Name = coworking.Name;
            editModel.Opening = coworking.Opening;
            editModel.Closing = coworking.Closing;
            editModel.Zones = new();
            editModel.Settings = new();
            ZoneService zoneService = new(serviceProvider);
            CSService csService = new(serviceProvider);
            foreach (Zone zone in coworking.Zones)
                editModel.Zones.Add(zoneService.DbZoneToEdit(zone));
            foreach (CoworkingSettings cs in coworking.Settings)
                editModel.Settings.Add(csService.DbCSToEdit(cs));
            return editModel;
        }

        public async Task UpdateCoworkingAsync(CoworkingEdit editModel)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(editModel.Id);
            coworking.Name = editModel.Name;
            coworking.Opening = editModel.Opening;
            coworking.Closing = editModel.Closing;
            await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
        }

        private CoworkingView CoworkingDbToView(Coworking coworking)
        {
            CoworkingView viewModel = new();
            viewModel.Id = coworking.Id;
            viewModel.Name = coworking.Name;
            viewModel.Opening = coworking.Opening;
            viewModel.Closing = coworking.Closing;
            viewModel.Zones = coworking.Zones.Select(zone => new ZoneView() { Id = zone.Id, Places = zone.Places.Select(place => new PlaceView() { Id = place.Id }).ToList() }).ToList();
            viewModel.Settings = coworking.Settings.Select(setting => new CSDTO() { Id = setting.Id, Closing = setting.Closing, Day = setting.Day, IsWorking = setting.IsWorking, Opening = setting.Opening }).ToList();
            return viewModel;
        }

        public async Task DeleteCoworkingAsync(Guid coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            await dataManager.Coworkings.DeleteCoworking(coworkingId);
        }
    }
}
